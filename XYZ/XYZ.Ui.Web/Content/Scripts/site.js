String.prototype.toDate = function () {
    //this "toDate" parse was made especifically for current context
    var milli = this.replace(/\/Date\((-?\d+)\)\//, '$1');
    var d = new Date(parseInt(milli));

    return d.getDay() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
}
$(function () {

    //#region [ Hubs ]

    var $table = $("#contactTable");

    function onParceiroRegistrado() {

    }
    function onAtualizado_Contato(contato) {
        var $row = $table.find("#contactId[value='" + contato.Id + "']").parentsUntil("tr");
        $row.find("#celular").val(contato.Celular);
        $row.find("#dataNascimento").val(contato.DtNasc);
    }
    function onEditando_Contato(idContato) {
        var $context = $table.find("#id[value='" + idContato + "']").parentsUntil(".contatoEntry");
        $context.trigger("change", { editing: true });
    }

    var contatosHub = $.connection.contatoHub;
    contatosHub.client.editando = onEditando_Contato;

    var parceirosHub = $.connection.parceiroHub;
    parceirosHub.client.registrado = onParceiroRegistrado;

    $.connection.hub.start().done(function () {


        React.renderComponent(
          ContatoList({ url: "/Contatos/Get?take=10" }),
          document.getElementById('contactTable')
        );

    });

    //#endregion [ Hubs ]
    //#region [ React Components ]

    var ContatoEntry = React.createClass({
        displayName: 'ContatoEntry',
        getInitialState: function () {
            return {};
        },
        onClick: function () {

            var contato = this.state.contato ? this.state.contato : this.props.contato;
            if (contatosHub.server.editar(contato.Id)) {
                contato.Editando = true;
                this.setState({ contato: contato });
            }

        },
        render: function () {
            var contato = this.state.contato ? this.state.contato : this.props.contato;
            var visible = { display: (contato.Editando ? "block" : "none") };
            return (React.DOM.div({ className: "contatoEntry" },
                React.DOM.div({ className: "block-overlay", style: visible }),
                React.DOM.div(null,
                    React.DOM.input({ id: "id", type: "hidden", value: this.props.contato.Id }),
                    React.DOM.label(null, "Id:   ", contato.Id),
                    React.DOM.label(null, "Nome: ", contato.Nome),
                    React.DOM.label(null, "Data de Nascimento: ", contato.DataNascimento.toDate()),
                    React.DOM.input({
                        type: "button", className: "btn-edit btn-primary"
                        , value: "Abrir", onClick: this.onClick.bind(this)
                    })
                )
            ));
        }
    });
    var ContatoList = React.createClass({
        displayName: 'ContatoList',
        getInitialState: function () {
            return { data: [] };
        },
        componentWillMount: function () {
            $.ajax({
                url: this.props.url,
                dataType: 'json',
                success: function (data) {
                    this.setState({ data: data });
                }.bind(this),
                error: function (xhr, status, err) {
                    console.error(this.props.url, status, err.toString());
                }.bind(this)
            });
        },
        render: function () {
            var contatoEntries = this.state.data.map(function (contato) {
                contatosHub.server.registrar(contato.Id);
                return ContatoEntry({ contato: contato });
            });
            return (React.DOM.div({ className: "contatoList" }, contatoEntries));
        }
    });

    //#endregion [ React Components ]


    function onClick_AbrirContatoEntry() {
        var $context = $(this).parentsUntil(".contatoEntry");
        contatosHub.server.editar($context.find("#id")[0].value);
    }

    //$(document).on('click', '.btn-edit', onClick_AbrirContatoEntry);
});