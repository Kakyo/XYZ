String.prototype.toDate = function () {
    //this "toDate" parse was made especifically for current context
    var d = new Date(this);

    if (isNaN(d.getDay()))
        return "";

    return d.getDay() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
}

$(function () {

    var loading = false;
    function loadEntries() {
        if (!loading) {
            loading = true;
            //  XYZ.Ui.Web.Hub.ContatoHub.GetContatos(int take) , server side C# function
            contatosHub.server.getContatos(20, contatoViewModel.itens().length);
        }
    }

    //#region [ Hub - Contato ]

    function onSet_Contato(list) {
        for (var i = 0, len = list.length; i < len; i++)
            contatoViewModel.itens.push(new ContatoItem(list[i]));
        loading = false;
    }
    function onAtualizado_Contato(idContato, celular, dtNasc) {
        contatoViewModel.updateContato(idContato, celular, dtNasc);
    }
    function onEditando_Contato(idContato, shouldBlock) {
        contatoViewModel.editContato(parseInt(idContato, 10), shouldBlock);
    }

    var contatosHub = $.connection.contatoHub;
    contatosHub.client.editando = onEditando_Contato;
    contatosHub.client.atualizado = onAtualizado_Contato;
    contatosHub.client.setContatos = onSet_Contato;

    $.connection.hub.start().done(loadEntries);

    //#endregion [ Hub - Contato ]
    //#region [ Knockout ]

    function ContatoItem(contato) {

        var self = this;
        var _init = !!contato;
        var _id = parseInt(_init ? contato.Id : -1, 10);

        //  XYZ.Ui.Web.Hub.ContatoHub.Registrar(string idContato) , server side C# function
        contatosHub.server.registrar(_id);
        self.Enabled = ko.observable(true);

        self.Init = _init;
        self.Id = _id;
        self.Nome = _init ? contato.Nome : "";
        self.Endereco = _init ? contato.Endereco : "";
        self.Telefone = _init ? contato.Telefone : "";
        self.Celular = ko.observable(_init ? contato.Celular : "");

        var dt = contato.DataNascimento ? contato.DataNascimento.toDate() : "";
        self.DataNascimento = ko.observable(_init ? dt : "");

    }
    function ContatoForm(contato) {

        var self = this;
        var _init = !!contato;
        var _id = parseInt(_init ? contato.Id : -1, 10);

        self.Enabled = ko.observable(_init);

        self.Id = _id;
        self.Nome = _init ? contato.Nome : "";
        self.Endereco = _init ? contato.Endereco : "";
        self.Telefone = _init ? contato.Telefone : "";
        self.Celular = ko.observable(_init ? contato.Celular() : "");
        self.DataNascimento = ko.observable(_init ? contato.DataNascimento().toDate() : "");

    }

    function ContatoViewModel() {
        //#region [ Methods ]

        function _getContatoIndex(idContato) {
            idContato = parseInt(idContato, 10);
            var list = self.itens();
            for (var i = 0, len = list.length; i < len; i++)
                if (list[i].Id === idContato)
                    return i;
        }
        function onEditContato(idContato, shouldBlock) {
            var i = _getContatoIndex(idContato);

            self.itens()[i].Enabled(!shouldBlock);
        }
        function onUpdateContato(idContato, celular, dtNasc) {
            var _item = self.itens()[_getContatoIndex(idContato)];

            _item.Enabled(true);
            _item.Celular(celular);
            _item.DataNascimento(dtNasc);
        }

        function onOpenContato(idContato) {
            var i = _getContatoIndex(idContato);

            self.form(new ContatoForm(self.itens()[i]));
            //  XYZ.Ui.Web.Hub.ContatoHub.Editar(string idContato) , server side C# function
            contatosHub.server.editar(idContato, true);
        }
        function onCloseContato(isPost) {
            var _form = self.form();

            _form.Enabled(false);

            if (isPost)
                //  XYZ.Ui.Web.Hub.ContatoHub.Atualizar
                //  (string idContato, string celular, string dataNascimento) 
                //  , server side C# function
                contatosHub.server.atualizar(_form.Id, _form.Celular(), _form.DataNascimento());
            else
                contatosHub.server.editar(_form.Id, false);
        }

        //#endregion [ Methods ]

        var self = this;
        self.itens = ko.observableArray();
        self.form = ko.observable(new ContatoForm());

        self.editContato = onEditContato;
        self.updateContato = onUpdateContato;
        self.openContato = onOpenContato;
        self.closeContato = onCloseContato;
    }

    var contatoViewModel = new ContatoViewModel();
    ko.applyBindings(contatoViewModel);

    //#endregion [ Knockout ]
    //#region [ Event Handlers ]

    function onClick_AbrirItem(ev) {
        ev.preventDefault();
        var idContato = $(this).closest(".contato-item").find(".contato-entry-id")[0].value;
        contatoViewModel.openContato(idContato);
    }
    function onCancel_Form(ev) {
        ev.preventDefault();
        contatoViewModel.closeContato(false);
    }
    function onSubmit_Form(ev) {
        ev.preventDefault();
        contatoViewModel.closeContato(true);
    }
    function onScroll_Page(ev) {
        if (detectScrollDirection() === -1
            && window.pageYOffset >= document.body.clientHeight - window.innerHeight - 400)
            loadEntries();
    }

    var lastScrollTop = 0, scrollDirection;
    function detectScrollDirection() {
        var st = window.pageYOffset;

        if (st > lastScrollTop) {
            // scrolling down
            scrollDirection = -1;
        } else if (st < lastScrollTop) {
            // scrolling up
            scrollDirection = 1;
        } else {
            // static
            scrollDirection = 0;
        }
        lastScrollTop = st;
        return scrollDirection;
    }

    $(document)
        .on('click', '.btn-item-edit', onClick_AbrirItem)
        .on('click', '.btn-form-cancel', onCancel_Form)
        .on('click', '.btn-form-submit', onSubmit_Form);

    $(window)
        .on('scroll', onScroll_Page);

    //#endregion [ Event Handlers ]

});