using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal class SageInvoice : IEntity
    {
        private Func<string> _tokenRetrievalFunc;
        private Func<string> _tokenSaveFunc;

        public SageInvoice(Func<string> tokenRetrievalFunc, Func<string> tokenSaveFunc)
        {
            _tokenRetrievalFunc = tokenRetrievalFunc;
            _tokenSaveFunc = tokenSaveFunc;
        }

        public void Create(object invoice, Action<object> successCallback, Action<Exception> errorCallback)
        {
            try
            {
                string Token = _tokenRetrievalFunc();

                if (invoice is Invoice)
                {
                    Invoice invoiceParams = (Invoice)invoice;
                    Invoice sageInvoice = new Invoice()
                    {
                        Id = invoiceParams.Id,
                        Name = invoiceParams.Name
                    };
                    // Do something with the client object
                    string save = _tokenSaveFunc();
                    successCallback?.Invoke(sageInvoice);
                }

            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
