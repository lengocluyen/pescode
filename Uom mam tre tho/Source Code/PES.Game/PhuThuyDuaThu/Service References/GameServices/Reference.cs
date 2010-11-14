﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 3.0.40624.0
// 
namespace PhuThuyDuaThu.GameServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameServices.GameServicesSoap")]
    public interface GameServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/UpdateScore", ReplyAction="*")]
        System.IAsyncResult BeginUpdateScore(PhuThuyDuaThu.GameServices.UpdateScoreRequest request, System.AsyncCallback callback, object asyncState);
        
        PhuThuyDuaThu.GameServices.UpdateScoreResponse EndUpdateScore(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GetChallengeID", ReplyAction="*")]
        System.IAsyncResult BeginGetChallengeID(int gameID, System.AsyncCallback callback, object asyncState);
        
        int EndGetChallengeID(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateScoreRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateScore", Namespace="http://tempuri.org/", Order=0)]
        public PhuThuyDuaThu.GameServices.UpdateScoreRequestBody Body;
        
        public UpdateScoreRequest() {
        }
        
        public UpdateScoreRequest(PhuThuyDuaThu.GameServices.UpdateScoreRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateScoreRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string hash;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int gameID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int score;
        
        public UpdateScoreRequestBody() {
        }
        
        public UpdateScoreRequestBody(string hash, int gameID, int score) {
            this.hash = hash;
            this.gameID = gameID;
            this.score = score;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateScoreResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateScoreResponse", Namespace="http://tempuri.org/", Order=0)]
        public PhuThuyDuaThu.GameServices.UpdateScoreResponseBody Body;
        
        public UpdateScoreResponse() {
        }
        
        public UpdateScoreResponse(PhuThuyDuaThu.GameServices.UpdateScoreResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateScoreResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int UpdateScoreResult;
        
        public UpdateScoreResponseBody() {
        }
        
        public UpdateScoreResponseBody(int UpdateScoreResult) {
            this.UpdateScoreResult = UpdateScoreResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface GameServicesSoapChannel : PhuThuyDuaThu.GameServices.GameServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UpdateScoreCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateScoreCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetChallengeIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetChallengeIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GameServicesSoapClient : System.ServiceModel.ClientBase<PhuThuyDuaThu.GameServices.GameServicesSoap>, PhuThuyDuaThu.GameServices.GameServicesSoap {
        
        private BeginOperationDelegate onBeginUpdateScoreDelegate;
        
        private EndOperationDelegate onEndUpdateScoreDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateScoreCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetChallengeIDDelegate;
        
        private EndOperationDelegate onEndGetChallengeIDDelegate;
        
        private System.Threading.SendOrPostCallback onGetChallengeIDCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public GameServicesSoapClient() {
        }
        
        public GameServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<UpdateScoreCompletedEventArgs> UpdateScoreCompleted;
        
        public event System.EventHandler<GetChallengeIDCompletedEventArgs> GetChallengeIDCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhuThuyDuaThu.GameServices.GameServicesSoap.BeginUpdateScore(PhuThuyDuaThu.GameServices.UpdateScoreRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateScore(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginUpdateScore(string hash, int gameID, int score, System.AsyncCallback callback, object asyncState) {
            PhuThuyDuaThu.GameServices.UpdateScoreRequest inValue = new PhuThuyDuaThu.GameServices.UpdateScoreRequest();
            inValue.Body = new PhuThuyDuaThu.GameServices.UpdateScoreRequestBody();
            inValue.Body.hash = hash;
            inValue.Body.gameID = gameID;
            inValue.Body.score = score;
            return ((PhuThuyDuaThu.GameServices.GameServicesSoap)(this)).BeginUpdateScore(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PhuThuyDuaThu.GameServices.UpdateScoreResponse PhuThuyDuaThu.GameServices.GameServicesSoap.EndUpdateScore(System.IAsyncResult result) {
            return base.Channel.EndUpdateScore(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private int EndUpdateScore(System.IAsyncResult result) {
            PhuThuyDuaThu.GameServices.UpdateScoreResponse retVal = ((PhuThuyDuaThu.GameServices.GameServicesSoap)(this)).EndUpdateScore(result);
            return retVal.Body.UpdateScoreResult;
        }
        
        private System.IAsyncResult OnBeginUpdateScore(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string hash = ((string)(inValues[0]));
            int gameID = ((int)(inValues[1]));
            int score = ((int)(inValues[2]));
            return this.BeginUpdateScore(hash, gameID, score, callback, asyncState);
        }
        
        private object[] OnEndUpdateScore(System.IAsyncResult result) {
            int retVal = this.EndUpdateScore(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateScoreCompleted(object state) {
            if ((this.UpdateScoreCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateScoreCompleted(this, new UpdateScoreCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateScoreAsync(string hash, int gameID, int score) {
            this.UpdateScoreAsync(hash, gameID, score, null);
        }
        
        public void UpdateScoreAsync(string hash, int gameID, int score, object userState) {
            if ((this.onBeginUpdateScoreDelegate == null)) {
                this.onBeginUpdateScoreDelegate = new BeginOperationDelegate(this.OnBeginUpdateScore);
            }
            if ((this.onEndUpdateScoreDelegate == null)) {
                this.onEndUpdateScoreDelegate = new EndOperationDelegate(this.OnEndUpdateScore);
            }
            if ((this.onUpdateScoreCompletedDelegate == null)) {
                this.onUpdateScoreCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateScoreCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateScoreDelegate, new object[] {
                        hash,
                        gameID,
                        score}, this.onEndUpdateScoreDelegate, this.onUpdateScoreCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhuThuyDuaThu.GameServices.GameServicesSoap.BeginGetChallengeID(int gameID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetChallengeID(gameID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int PhuThuyDuaThu.GameServices.GameServicesSoap.EndGetChallengeID(System.IAsyncResult result) {
            return base.Channel.EndGetChallengeID(result);
        }
        
        private System.IAsyncResult OnBeginGetChallengeID(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int gameID = ((int)(inValues[0]));
            return ((PhuThuyDuaThu.GameServices.GameServicesSoap)(this)).BeginGetChallengeID(gameID, callback, asyncState);
        }
        
        private object[] OnEndGetChallengeID(System.IAsyncResult result) {
            int retVal = ((PhuThuyDuaThu.GameServices.GameServicesSoap)(this)).EndGetChallengeID(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetChallengeIDCompleted(object state) {
            if ((this.GetChallengeIDCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetChallengeIDCompleted(this, new GetChallengeIDCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetChallengeIDAsync(int gameID) {
            this.GetChallengeIDAsync(gameID, null);
        }
        
        public void GetChallengeIDAsync(int gameID, object userState) {
            if ((this.onBeginGetChallengeIDDelegate == null)) {
                this.onBeginGetChallengeIDDelegate = new BeginOperationDelegate(this.OnBeginGetChallengeID);
            }
            if ((this.onEndGetChallengeIDDelegate == null)) {
                this.onEndGetChallengeIDDelegate = new EndOperationDelegate(this.OnEndGetChallengeID);
            }
            if ((this.onGetChallengeIDCompletedDelegate == null)) {
                this.onGetChallengeIDCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetChallengeIDCompleted);
            }
            base.InvokeAsync(this.onBeginGetChallengeIDDelegate, new object[] {
                        gameID}, this.onEndGetChallengeIDDelegate, this.onGetChallengeIDCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PhuThuyDuaThu.GameServices.GameServicesSoap CreateChannel() {
            return new GameServicesSoapClientChannel(this);
        }
        
        private class GameServicesSoapClientChannel : ChannelBase<PhuThuyDuaThu.GameServices.GameServicesSoap>, PhuThuyDuaThu.GameServices.GameServicesSoap {
            
            public GameServicesSoapClientChannel(System.ServiceModel.ClientBase<PhuThuyDuaThu.GameServices.GameServicesSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginUpdateScore(PhuThuyDuaThu.GameServices.UpdateScoreRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("UpdateScore", _args, callback, asyncState);
                return _result;
            }
            
            public PhuThuyDuaThu.GameServices.UpdateScoreResponse EndUpdateScore(System.IAsyncResult result) {
                object[] _args = new object[0];
                PhuThuyDuaThu.GameServices.UpdateScoreResponse _result = ((PhuThuyDuaThu.GameServices.UpdateScoreResponse)(base.EndInvoke("UpdateScore", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetChallengeID(int gameID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = gameID;
                System.IAsyncResult _result = base.BeginInvoke("GetChallengeID", _args, callback, asyncState);
                return _result;
            }
            
            public int EndGetChallengeID(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("GetChallengeID", _args, result)));
                return _result;
            }
        }
    }
}