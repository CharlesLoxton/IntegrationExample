using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal class AccountingProviderFactory
    {
        public Func<string> _tokenRetrievalFunc;
        public Func<string> _tokenSaveFunc;

        public AccountingProviderFactory(Func<string> tokenRetrievalFunc, Func<string> tokenSaveFunc)
        {
            _tokenRetrievalFunc = tokenRetrievalFunc;
            _tokenSaveFunc = tokenSaveFunc;
        }

        public IEntity GetProvider(string providerName, string entityName)
        {
            switch (providerName)
            {
                case "Sage":
                    switch (entityName)
                    {
                        case "Client":
                            return new SageClient(_tokenRetrievalFunc, _tokenSaveFunc);
                        case "Invoice":
                            return new SageInvoice(_tokenRetrievalFunc, _tokenSaveFunc);
                        case "Quote":
                            return new SageQuote(_tokenRetrievalFunc, _tokenSaveFunc);
                        case "PurchaseOrder":
                            return new SagePurchaseOrder(_tokenRetrievalFunc, _tokenSaveFunc);
                        default:
                            throw new ArgumentException("Invalid provider name");
                    }
                case "Xero":
                    //return new XeroProvider(tokenRetrievalFunc);
                case "Quickbooks":
                    //return new QuickbooksProvider(tokenRetrievalFunc);
                default:
                    throw new ArgumentException("Invalid provider name");
            }
        }
    }
}
