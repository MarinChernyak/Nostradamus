//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NostraTester.NostraSrv {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NostraSrv.INostraSrv")]
    public interface INostraSrv {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/IsAlive", ReplyAction="http://tempuri.org/INostraSrv/IsAliveResponse")]
        bool IsAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/IsAlive", ReplyAction="http://tempuri.org/INostraSrv/IsAliveResponse")]
        System.Threading.Tasks.Task<bool> IsAliveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/GetCompletePersonalDataById", ReplyAction="http://tempuri.org/INostraSrv/GetCompletePersonalDataByIdResponse")]
        NostraDataContracts.PersonalRecord GetCompletePersonalDataById(int ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/GetCompletePersonalDataById", ReplyAction="http://tempuri.org/INostraSrv/GetCompletePersonalDataByIdResponse")]
        System.Threading.Tasks.Task<NostraDataContracts.PersonalRecord> GetCompletePersonalDataByIdAsync(int ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/GetDisplayPersonalRecordById", ReplyAction="http://tempuri.org/INostraSrv/GetDisplayPersonalRecordByIdResponse")]
        NostraDataContracts.DisplayPersonalRecord GetDisplayPersonalRecordById(int ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INostraSrv/GetDisplayPersonalRecordById", ReplyAction="http://tempuri.org/INostraSrv/GetDisplayPersonalRecordByIdResponse")]
        System.Threading.Tasks.Task<NostraDataContracts.DisplayPersonalRecord> GetDisplayPersonalRecordByIdAsync(int ID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INostraSrvChannel : NostraTester.NostraSrv.INostraSrv, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NostraSrvClient : System.ServiceModel.ClientBase<NostraTester.NostraSrv.INostraSrv>, NostraTester.NostraSrv.INostraSrv {
        
        public NostraSrvClient() {
        }
        
        public NostraSrvClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NostraSrvClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NostraSrvClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NostraSrvClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsAlive() {
            return base.Channel.IsAlive();
        }
        
        public System.Threading.Tasks.Task<bool> IsAliveAsync() {
            return base.Channel.IsAliveAsync();
        }
        
        public NostraDataContracts.PersonalRecord GetCompletePersonalDataById(int ID) {
            return base.Channel.GetCompletePersonalDataById(ID);
        }
        
        public System.Threading.Tasks.Task<NostraDataContracts.PersonalRecord> GetCompletePersonalDataByIdAsync(int ID) {
            return base.Channel.GetCompletePersonalDataByIdAsync(ID);
        }
        
        public NostraDataContracts.DisplayPersonalRecord GetDisplayPersonalRecordById(int ID) {
            return base.Channel.GetDisplayPersonalRecordById(ID);
        }
        
        public System.Threading.Tasks.Task<NostraDataContracts.DisplayPersonalRecord> GetDisplayPersonalRecordByIdAsync(int ID) {
            return base.Channel.GetDisplayPersonalRecordByIdAsync(ID);
        }
    }
}
