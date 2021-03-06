﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatusServiceTestClient.StatusServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/StatusServiceLiberary")]
    [System.SerializableAttribute()]
    public partial class Status : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Number {
            get {
                return this.NumberField;
            }
            set {
                if ((this.NumberField.Equals(value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.smartborder.com/SBNET/USB/IEntryStatusService", ConfigurationName="StatusServiceReference.IStatusService", CallbackContract=typeof(StatusServiceTestClient.StatusServiceReference.IStatusServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IStatusService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.smartborder.com/SBNET/USB/IEntryStatusService/IStatusService/Subscribe" +
            "")]
        void Subscribe(string entryNumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.smartborder.com/SBNET/USB/IEntryStatusService/IStatusService/Subscribe" +
            "")]
        System.Threading.Tasks.Task SubscribeAsync(string entryNumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.smartborder.com/SBNET/USB/IEntryStatusService/IStatusService/Unsubscri" +
            "be")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.smartborder.com/SBNET/USB/IEntryStatusService/IStatusService/Unsubscri" +
            "be")]
        System.Threading.Tasks.Task UnsubscribeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStatusServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.smartborder.com/SBNET/USB/IEntryStatusService/IStatusService/OnStatusU" +
            "pdate")]
        void OnStatusUpdate(StatusServiceTestClient.StatusServiceReference.Status S);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStatusServiceChannel : StatusServiceTestClient.StatusServiceReference.IStatusService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StatusServiceClient : System.ServiceModel.DuplexClientBase<StatusServiceTestClient.StatusServiceReference.IStatusService>, StatusServiceTestClient.StatusServiceReference.IStatusService {
        
        public StatusServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StatusServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StatusServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StatusServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StatusServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Subscribe(string entryNumber) {
            base.Channel.Subscribe(entryNumber);
        }
        
        public System.Threading.Tasks.Task SubscribeAsync(string entryNumber) {
            return base.Channel.SubscribeAsync(entryNumber);
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
    }
}
