﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.WebServiceSoap")]
    public interface WebServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 HelloWorldResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        WebApplication4.ServiceReference.HelloWorldResponse HelloWorld(WebApplication4.ServiceReference.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication4.ServiceReference.HelloWorldResponse> HelloWorldAsync(WebApplication4.ServiceReference.HelloWorldRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 username 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetUpMassageDate", ReplyAction="*")]
        WebApplication4.ServiceReference.GetUpMassageDateResponse GetUpMassageDate(WebApplication4.ServiceReference.GetUpMassageDateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetUpMassageDate", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication4.ServiceReference.GetUpMassageDateResponse> GetUpMassageDateAsync(WebApplication4.ServiceReference.GetUpMassageDateRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication4.ServiceReference.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(WebApplication4.ServiceReference.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication4.ServiceReference.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(WebApplication4.ServiceReference.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUpMassageDateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUpMassageDate", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication4.ServiceReference.GetUpMassageDateRequestBody Body;
        
        public GetUpMassageDateRequest() {
        }
        
        public GetUpMassageDateRequest(WebApplication4.ServiceReference.GetUpMassageDateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetUpMassageDateRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        public GetUpMassageDateRequestBody() {
        }
        
        public GetUpMassageDateRequestBody(string username) {
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUpMassageDateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUpMassageDateResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication4.ServiceReference.GetUpMassageDateResponseBody Body;
        
        public GetUpMassageDateResponse() {
        }
        
        public GetUpMassageDateResponse(WebApplication4.ServiceReference.GetUpMassageDateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetUpMassageDateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement GetUpMassageDateResult;
        
        public GetUpMassageDateResponseBody() {
        }
        
        public GetUpMassageDateResponseBody(System.Xml.Linq.XElement GetUpMassageDateResult) {
            this.GetUpMassageDateResult = GetUpMassageDateResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : WebApplication4.ServiceReference.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<WebApplication4.ServiceReference.WebServiceSoap>, WebApplication4.ServiceReference.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication4.ServiceReference.HelloWorldResponse WebApplication4.ServiceReference.WebServiceSoap.HelloWorld(WebApplication4.ServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            WebApplication4.ServiceReference.HelloWorldRequest inValue = new WebApplication4.ServiceReference.HelloWorldRequest();
            inValue.Body = new WebApplication4.ServiceReference.HelloWorldRequestBody();
            WebApplication4.ServiceReference.HelloWorldResponse retVal = ((WebApplication4.ServiceReference.WebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication4.ServiceReference.HelloWorldResponse> WebApplication4.ServiceReference.WebServiceSoap.HelloWorldAsync(WebApplication4.ServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication4.ServiceReference.HelloWorldResponse> HelloWorldAsync() {
            WebApplication4.ServiceReference.HelloWorldRequest inValue = new WebApplication4.ServiceReference.HelloWorldRequest();
            inValue.Body = new WebApplication4.ServiceReference.HelloWorldRequestBody();
            return ((WebApplication4.ServiceReference.WebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication4.ServiceReference.GetUpMassageDateResponse WebApplication4.ServiceReference.WebServiceSoap.GetUpMassageDate(WebApplication4.ServiceReference.GetUpMassageDateRequest request) {
            return base.Channel.GetUpMassageDate(request);
        }
        
        public System.Xml.Linq.XElement GetUpMassageDate(string username) {
            WebApplication4.ServiceReference.GetUpMassageDateRequest inValue = new WebApplication4.ServiceReference.GetUpMassageDateRequest();
            inValue.Body = new WebApplication4.ServiceReference.GetUpMassageDateRequestBody();
            inValue.Body.username = username;
            WebApplication4.ServiceReference.GetUpMassageDateResponse retVal = ((WebApplication4.ServiceReference.WebServiceSoap)(this)).GetUpMassageDate(inValue);
            return retVal.Body.GetUpMassageDateResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication4.ServiceReference.GetUpMassageDateResponse> WebApplication4.ServiceReference.WebServiceSoap.GetUpMassageDateAsync(WebApplication4.ServiceReference.GetUpMassageDateRequest request) {
            return base.Channel.GetUpMassageDateAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication4.ServiceReference.GetUpMassageDateResponse> GetUpMassageDateAsync(string username) {
            WebApplication4.ServiceReference.GetUpMassageDateRequest inValue = new WebApplication4.ServiceReference.GetUpMassageDateRequest();
            inValue.Body = new WebApplication4.ServiceReference.GetUpMassageDateRequestBody();
            inValue.Body.username = username;
            return ((WebApplication4.ServiceReference.WebServiceSoap)(this)).GetUpMassageDateAsync(inValue);
        }
    }
}
