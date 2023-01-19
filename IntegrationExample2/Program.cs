using IntegrationExample2;

Client client = new Client()
{
    Id = 1,
    Name = "Sage Client"
};


Func<string> tokenRetrievalFunc = GetToken;
Func<string> tokenSaveFunc = SaveToken;

AccountingProviderFactory factory = new AccountingProviderFactory(tokenRetrievalFunc, tokenSaveFunc);

IEntity provider = factory.GetProvider("Sage", "Client");

provider.Create(client,
            (result) => {
                // do something with the returned invoice
                Client info = (Client)result;
                Console.WriteLine("Client created with ID: " + info.Id);
            },
            (ex) => {
                // do something with the exception
                Console.WriteLine("Error occured while creating invoice: " + ex.Message);
            }
);

string GetToken()
{
    Console.WriteLine("Retrieving Token from KOST");
    //Logic for getting token from KOST
    return "Token";
}

string SaveToken()
{
    Console.WriteLine("Saving new Token in KOST");
    //Logic for saving token in KOST
    return "Success";
}
