﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XYZ.Services.SrContato {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SrContato.IContatoService")]
    internal interface IContatoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContatoService/Ping", ReplyAction="http://tempuri.org/IContatoService/PingResponse")]
        bool Ping();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContatoService/GetContatos", ReplyAction="http://tempuri.org/IContatoService/GetContatosResponse")]
        System.Collections.Generic.List<XYZ.Domain.Contato> GetContatos(int take, int skip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContatoService/UpdateContato", ReplyAction="http://tempuri.org/IContatoService/UpdateContatoResponse")]
        XYZ.Domain.Contato UpdateContato(long idContato, string celular, System.DateTime dataNasc);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IContatoServiceChannel : XYZ.Services.SrContato.IContatoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class ContatoServiceClient : System.ServiceModel.ClientBase<XYZ.Services.SrContato.IContatoService>, XYZ.Services.SrContato.IContatoService {
        
        public ContatoServiceClient() {
        }
        
        public ContatoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ContatoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContatoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContatoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Ping() {
            return base.Channel.Ping();
        }
        
        public System.Collections.Generic.List<XYZ.Domain.Contato> GetContatos(int take, int skip) {
            return base.Channel.GetContatos(take, skip);
        }
        
        public XYZ.Domain.Contato UpdateContato(long idContato, string celular, System.DateTime dataNasc) {
            return base.Channel.UpdateContato(idContato, celular, dataNasc);
        }
    }
}
