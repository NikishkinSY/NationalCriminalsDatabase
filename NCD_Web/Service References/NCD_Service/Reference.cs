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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NCD_Service.ISearch")]
    public interface ISearch {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearch/GetCriminalPersons", ReplyAction="http://tempuri.org/ISearch/GetCriminalPersonsResponse")]
        NCD_Web.NCD_Service.GetCriminalPersonsResponse GetCriminalPersons(NCD_Web.NCD_Service.GetCriminalPersonsRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearch/GetCriminalPersons", ReplyAction="http://tempuri.org/ISearch/GetCriminalPersonsResponse")]
        System.Threading.Tasks.Task<NCD_Web.NCD_Service.GetCriminalPersonsResponse> GetCriminalPersonsAsync(NCD_Web.NCD_Service.GetCriminalPersonsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCriminalPersons", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetCriminalPersonsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public NCD_Web.NCD_Service.SearchParams searchParams;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string email;
        
        public GetCriminalPersonsRequest() {
        }
        
        public GetCriminalPersonsRequest(NCD_Web.NCD_Service.SearchParams searchParams, string email) {
            this.searchParams = searchParams;
            this.email = email;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCriminalPersonsResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetCriminalPersonsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool GetCriminalPersonsResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string result;
        
        public GetCriminalPersonsResponse() {
        }
        
        public GetCriminalPersonsResponse(bool GetCriminalPersonsResult, string result) {
            this.GetCriminalPersonsResult = GetCriminalPersonsResult;
            this.result = result;
        }
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
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NCD_Web.NCD_Service.GetCriminalPersonsResponse NCD_Web.NCD_Service.ISearch.GetCriminalPersons(NCD_Web.NCD_Service.GetCriminalPersonsRequest request) {
            return base.Channel.GetCriminalPersons(request);
        }
        
        public bool GetCriminalPersons(NCD_Web.NCD_Service.SearchParams searchParams, string email, out string result) {
            NCD_Web.NCD_Service.GetCriminalPersonsRequest inValue = new NCD_Web.NCD_Service.GetCriminalPersonsRequest();
            inValue.searchParams = searchParams;
            inValue.email = email;
            NCD_Web.NCD_Service.GetCriminalPersonsResponse retVal = ((NCD_Web.NCD_Service.ISearch)(this)).GetCriminalPersons(inValue);
            result = retVal.result;
            return retVal.GetCriminalPersonsResult;
        }
        
        public System.Threading.Tasks.Task<NCD_Web.NCD_Service.GetCriminalPersonsResponse> GetCriminalPersonsAsync(NCD_Web.NCD_Service.GetCriminalPersonsRequest request) {
            return base.Channel.GetCriminalPersonsAsync(request);
        }
    }
}
