using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal class SageClient : IEntity
    {
        private Func<string> _tokenRetrievalFunc;
        private Func<string> _tokenSaveFunc;

        public SageClient(Func<string> tokenRetrievalFunc, Func<string> tokenSaveFunc)
        {
            _tokenRetrievalFunc = tokenRetrievalFunc;
            _tokenSaveFunc = tokenSaveFunc;
        }

        public void Create(object client, Action<object> successCallback, Action<Exception> errorCallback)
        {
            try
            {
                string Token = _tokenRetrievalFunc();
                if (client is Client)
                {
                    Client clientParams = (Client)client;
                    Client sageClient = new Client()
                    {
                        Id = clientParams.Id,
                        Name = clientParams.Name
                    };

                    Console.WriteLine("Creating Client in Sage");
                    
                    string save = _tokenSaveFunc();
                    successCallback?.Invoke(sageClient);
                }
            }
            catch(Exception ex)
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
