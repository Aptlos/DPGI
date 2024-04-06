namespace DPGI_Lab3;

public class Currency
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    public double Exchange { get; set; }

    public override string ToString()
    {
        return string.Format("{0} \nCode: {1}", Name, Code);
    }
}