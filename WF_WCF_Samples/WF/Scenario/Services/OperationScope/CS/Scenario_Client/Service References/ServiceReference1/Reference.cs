﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.20604.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Scenario_Client.ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bank.org", ConfigurationName="ServiceReference1.IBankService")]
    public interface IBankService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bank.org/IBankService/OpenAccount", ReplyAction="http://bank.org/IBankService/OpenAccountResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Result")]
        double OpenAccount(double X);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bank.org/IBankService/Deposit", ReplyAction="http://bank.org/IBankService/DepositResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Result")]
        double Deposit(double X);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bank.org/IBankService/Withdraw", ReplyAction="http://bank.org/IBankService/WithdrawResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Result")]
        double Withdraw(double Y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bank.org/IBankService/CloseAccount", ReplyAction="http://bank.org/IBankService/CloseAccountResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Result")]
        double CloseAccount();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankServiceChannel : Scenario_Client.ServiceReference1.IBankService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankServiceClient : System.ServiceModel.ClientBase<Scenario_Client.ServiceReference1.IBankService>, Scenario_Client.ServiceReference1.IBankService {
        
        public BankServiceClient() {
        }
        
        public BankServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double OpenAccount(double X) {
            return base.Channel.OpenAccount(X);
        }
        
        public double Deposit(double X) {
            return base.Channel.Deposit(X);
        }
        
        public double Withdraw(double Y) {
            return base.Channel.Withdraw(Y);
        }
        
        public double CloseAccount() {
            return base.Channel.CloseAccount();
        }
    }
}
