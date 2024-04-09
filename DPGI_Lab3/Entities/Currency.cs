namespace DPGI_Lab3;

public class Currency
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    public double Exchange { get; set; }

    public override string ToString()
    {
        return string.Format("{0} Code: {1}\nExchange rate: {2}", Name, Code,Exchange);
    }
}