using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XYZ.Interfaces.Services;
using signalr = Microsoft.AspNet.SignalR;

namespace XYZ.Ui.Web.Hub
{
    public class ContatoHub : signalr.Hub
    {
        private readonly IContatoService _SrContato;
        public ContatoHub(IContatoService srContato)
        {
            this._SrContato = srContato;
        }

        private string GetId(string idContato)
        {
            return string.Format("contato.{0}", idContato);
        }
        private bool Try(string idContato
            , Action<string, string> onTry
            , Action<string, string> onException = null)
        {
            string conId = this.Context.ConnectionId;
            string groupId = this.GetId(idContato);
            try
            {
                onTry(conId, groupId);
                return true;
            }
            catch
            {
                if (onException != null)
                    onException(conId, groupId);
                return false;
            }
        }

        public void GetContatos(int take, int skip)
        {
            var list = this._SrContato.GetContatos(take, skip);
            //  setContatos, on client side (javascript function)
            this.Clients.Caller.setContatos(list);
        }
        public bool Atualizar(string idContato, string celular, string dataNasc)
        {
            return Try(idContato,
                (connId, groupId) =>
                {
                    DateTime dtNasc;
                    DateTime.TryParse(dataNasc, out dtNasc);
                    //  repository update entry;
                    this._SrContato.UpdateContato(long.Parse(idContato), celular, dtNasc);
                    //  Atualizado, on client side (javascript function)
                    this.Clients.Group(groupId).Atualizado(idContato, celular, dataNasc);
                });
        }

        public bool Registrar(string idContato)
        {
            return Try(idContato,
                (connId, groupId) => this.Groups.Add(connId, groupId),
                (connId, groupId) => this.Groups.Remove(connId, groupId));
        }
        public bool Editar(string idContato, bool shouldBlock)
        {
            //  Editando, on client side (javascript function)
            return Try(idContato,
                (connId, groupId) => this.Clients.Group(groupId).Editando(idContato, shouldBlock));
        }
    }
}