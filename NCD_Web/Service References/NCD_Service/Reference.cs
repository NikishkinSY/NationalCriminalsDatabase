﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCD_Web.NCD_Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchParams", Namespace="http://schemas.datacontract.org/2004/07/NCD_WebService")]
    [System.SerializableAttribute()]
    public partial class SearchParams : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> EndAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<ushort> EndHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<ushort> EndWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] NamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] NationalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> StartAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<ushort> StartHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<ushort> StartWeightField;
        
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
        public System.Nullable<byte> EndAge {
            get {
                return this.EndAgeField;
            }
            set {
                if ((this.EndAgeField.Equals(value) != true)) {
                    this.EndAgeField = value;
                    this.RaisePropertyChanged("EndAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<ushort> EndHeight {
            get {
                return this.EndHeightField;
            }
            set {
                if ((this.EndHeightField.Equals(value) != true)) {
                    this.EndHeightField = value;
                    this.RaisePropertyChanged("EndHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<ushort> EndWeight {
            get {
                return this.EndWeightField;
            }
            set {
                if ((this.EndWeightField.Equals(value) != true)) {
                    this.EndWeightField = value;
                    this.RaisePropertyChanged("EndWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Names {
            get {
                return this.NamesField;
            }
            set {
                if ((object.ReferenceEquals(this.NamesField, value) != true)) {
                    this.NamesField = value;
                    this.RaisePropertyChanged("Names");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Nationality {
            get {
                return this.NationalityField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalityField, value) != true)) {
                    this.NationalityField = value;
                    this.RaisePropertyChanged("Nationality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Sex {
            get {
                return this.SexField;
            }
            set {
                if ((this.SexField.Equals(value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> StartAge {
            get {
                return this.StartAgeField;
            }
            set {
                if ((this.StartAgeField.Equals(value) != true)) {
                    this.StartAgeField = value;
                    this.RaisePropertyChanged("StartAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<ushort> StartHeight {
            get {
                return this.StartHeightField;
            }
            set {
                if ((this.StartHeightField.Equals(value) != true)) {
                    this.StartHeightField = value;
                    this.RaisePropertyChanged("StartHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<ushort> StartWeight {
            get {
                return this.StartWeightField;
            }
            set {
                if ((this.StartWeightField.Equals(value) != true)) {
                    this.StartWeightField = value;
                    this.RaisePropertyChanged("StartWeight");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/NCD_WebService")]
    [System.SerializableAttribute()]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
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
        public string Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorField, value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NCD_Service.ISearch")]
    public interface ISearch {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearch/GetCriminalPersons", ReplyAction="http://tempuri.org/ISearch/GetCriminalPersonsResponse")]
        NCD_Web.NCD_Service.Result GetCriminalPersons(NCD_Web.NCD_Service.SearchParams searchParams, int maxItems, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearch/GetCriminalPersons", ReplyAction="http://tempuri.org/ISearch/GetCriminalPersonsResponse")]
        System.Threading.Tasks.Task<NCD_Web.NCD_Service.Result> GetCriminalPersonsAsync(NCD_Web.NCD_Service.SearchParams searchParams, int maxItems, string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISearchChannel : NCD_Web.NCD_Service.ISearch, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SearchClient : System.ServiceModel.ClientBase<NCD_Web.NCD_Service.ISearch>, NCD_Web.NCD_Service.ISearch {
        
        public SearchClient() {
        }
        
        public SearchClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SearchClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NCD_Web.NCD_Service.Result GetCriminalPersons(NCD_Web.NCD_Service.SearchParams searchParams, int maxItems, string email) {
            return base.Channel.GetCriminalPersons(searchParams, maxItems, email);
        }
        
        public System.Threading.Tasks.Task<NCD_Web.NCD_Service.Result> GetCriminalPersonsAsync(NCD_Web.NCD_Service.SearchParams searchParams, int maxItems, string email) {
            return base.Channel.GetCriminalPersonsAsync(searchParams, maxItems, email);
        }
    }
}
