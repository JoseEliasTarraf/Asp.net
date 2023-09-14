using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{

    //Modelo para as Request de Adição
    public class CountryAddResquest
    {
        public string? CountryName { get; set; }

        public Country ToCountry()
        {
            return new Country()
            {
                //Só é salvo o Nome pois é o
                //Modelo de Dominio que ira gerar o ID
                CountryName = CountryName
            };
        }
    }
}
