using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal class SageQuote : IEntity
    {
        private Func<string> _tokenRetrievalFunc;
        private Func<string> _tokenSaveFunc;

        public SageQuote(Func<string> tokenRetrievalFunc, Func<string> tokenSaveFunc)
        {
            _tokenRetrievalFunc = tokenRetrievalFunc;
            _tokenSaveFunc = tokenSaveFunc;
        }

        public void Create(object quote, Action<object>? successCallback, Action<Exception>? errorCallback)
        {
            try
            {
                string Token = _tokenRetrievalFunc();
                if (quote is Quote)
                {
                    Quote quoteParams = (Quote)quote;
                    Quote sageQuote = new Quote()
                    {
                        Id = quoteParams.Id,
                        Name = quoteParams.Name
                    };
                    // Do something with the client object
                    string save = _tokenSaveFunc();
                    successCallback?.Invoke(sageQuote);
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
