using System.Collections;

namespace DPGI_Lab3;

public class CurrencyCollection : ArrayList
{
     public CurrencyCollection() 
     {
          Add(new Currency { Name = "Українська гривня", Code = "UAH",Exchange=1 });
          Add(new Currency { Name = "Долар США", Code = "USD",Exchange=0.026 });
          Add(new Currency { Name = "Євро ", Code = "EUR",Exchange=0.024 });
          Add(new Currency { Name = "Фунт стерлінгів", Code = "GBP",Exchange=0.020 });
          Add(new Currency { Name = "Турецька ліра", Code = "TRY",Exchange=0.83 });
          Add(new Currency { Name = "Шведська крона", Code = "SEK",Exchange=0.27 });
          Add(new Currency { Name = "Чеська крона", Code = "CZK",Exchange=0.60 });
          Add(new Currency { Name = "Швейцарський франк", Code = "CHF",Exchange=0.023 });
          Add(new Currency { Name = "Польський злотий", Code = "PLN",Exchange=0.10 });
          Add(new Currency { Name = "Японська єна", Code = "JPY",Exchange=3.9 });
          Add(new Currency { Name = "Китайський юань", Code = "CNH",Exchange=0.19 });
          Add(new Currency { Name = "Південнокорейська вона", Code = "KRW",Exchange=34.84 });
          Add(new Currency { Name = "Бразильський реал", Code = "BRL",Exchange=0.13 });
          Add(new Currency { Name = "Грузинський ларі", Code = "GEL",Exchange=0.069 });
          Add(new Currency { Name = "Дірхам ОАЕ", Code = "AED",Exchange=0.094 });

     }
}