
using ApiConsumer;
using MainCallApis;
using System.Collections;
using System.Globalization;
using System.Resources;

class Program
{
    static async Task Main()
    {
        ResourceSet? resourceSet = SetupApis();
        await CallApis(resourceSet);
    }

    static async Task CallApis(ResourceSet? resourceSet)
    {
        if (resourceSet != null)
        {
            foreach (DictionaryEntry entry in resourceSet)
            {
                var response = await ApiConsumerMain.GetResponseApi(entry.Value.ToString());

                if (response != null)
                {
                    Console.WriteLine($"Response from {entry.Value} is:" + Environment.NewLine + $"{response}" + Environment.NewLine + Environment.NewLine);
                }
               
            }
        }
    
    }

    static ResourceSet? SetupApis()
    {
        var culture = CultureInfo.InvariantCulture;
        var resourceManager = Resources.ResourceManager;
        return resourceManager.GetResourceSet(culture, createIfNotExists: true, tryParents: true);
    }

}
