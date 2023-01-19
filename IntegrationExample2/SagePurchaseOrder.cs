using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal class SagePurchaseOrder : IEntity
    {
        private Func<string> _tokenRetrievalFunc;
        private Func<string> _tokenSaveFunc;

        public SagePurchaseOrder(Func<string> tokenRetrievalFunc, Func<string> tokenSaveFunc)
        {
            _tokenRetrievalFunc = tokenRetrievalFunc;
            _tokenSaveFunc = tokenSaveFunc;
        }

        public void Create(object po, Action<object> successCallback, Action<Exception> errorCallback)
        {
            try
            {
                string Token = _tokenRetrievalFunc();
                if (po is PurchaseOrder)
                {
                    PurchaseOrder poParams = (PurchaseOrder)po;
                    PurchaseOrder sagePO = new PurchaseOrder()
                    {
                        Id = poParams.Id,
                        Name = poParams.Name
                    };
                    // Do something with the client object
                    string save = _tokenSaveFunc();
                    successCallback?.Invoke(sagePO);
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
