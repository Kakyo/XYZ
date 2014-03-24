using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using signalr = Microsoft.AspNet.SignalR;

namespace XYZ.Ui.Web.Hub
{
    public class ContatoHub : signalr.Hub
    {
        private string GetId(string idContato)
        {
            return string.Format("contato.{0}", idContato);
        }
        public bool Try(string idContato
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

        public bool Registrar(string idContato)
        {
            return Try(idContato, (connId, groupId) => Groups.Add(connId, groupId),
                (connId, groupId) => Groups.Remove(connId, groupId));
        }
        public bool Editar(string idContato)
        {
            //  Editando, on client side (javascript function)
            return Try(idContato, (connId, groupId) 
                => Clients.Group(groupId).Editando(idContato));
        }
        public bool Atualizar(string idContato, string telefone, string dataNasc)
        {
            return Try(idContato, (connId, groupId) =>
            {
                //  repository update entry;
                //  repo.Update(idContato, telefone, dataNasc)
                //  Atualizado, on client side (javascript function)
                Clients.Group(groupId).Atualizado(idContato, telefone, dataNasc);
            });
        }
    }
}