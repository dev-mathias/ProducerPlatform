using BLL_Producteur.Entities;
using Newtonsoft.Json;
using ProducteurPlateformeAPI.Models;
using QuickType;
using System.Net.Http.Headers;

namespace ProducteurPlateformeAPI.Mappers
{
    public static class AdressMapper
    {
        public static async Task<Address> GetCoordGpsAsync( this AddressForm address)
        {
            Address adresseGeo=null;
            string apiKey = "c9b725e000bd44ca97fb72ea50aaa8fe";
            string Url = "https://api.geoapify.com/v1/geocode/search?housenumber=" + address.Numero +
                          "&street=" + address.Rue +
                          "&postcode=" + address.CodePostal +
                          "&city=" + address.Ville +
                          "&country=" + address.Pays +
                          "&format=json" +
                          "&apiKey=" + apiKey;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(Url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                AdressApiResult responseObject = JsonConvert.DeserializeObject<AdressApiResult>(result);
                adresseGeo = responseObject.toAdresse();
            }
            adresseGeo.Rue=address.Rue;
            adresseGeo.CodePostal = address.CodePostal;
            adresseGeo.Ville = address.Ville;
            adresseGeo.Numero=address.Numero;
            adresseGeo.Pays = address.Pays;
            return adresseGeo;
        }
    }
}
