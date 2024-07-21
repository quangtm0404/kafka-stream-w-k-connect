using Avro;
using Avro.Specific;

public class User : ISpecificRecord
{
    public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""User"",""namespace"":""confluent.io.examples.serialization.avro"",""fields"":    
                [{""name"":""NAME"",""type"":""string""},{""name"":""FAVORITE_NUMBER"",""type"":""int""}
                ,{""name"":""FAVORITE_COLOR"",""type"":""string""}]}");
    private string _name = "N/A";
    private int _favorite_number = 0;
    private string _favorite_color = "N/A";
    public virtual Schema Schema
    {
        get
        {
            return User._SCHEMA;
        }
    }
    public string name
    {
        get
        {
            return this._name;
        }
        set
        {
            this._name = value;
        }
    }
    public int favorite_number
    {
        get
        {
            return this._favorite_number;
        }
        set
        {
            this._favorite_number = value;
        }
    }
    public string favorite_color
    {
        get
        {
            return this._favorite_color;
        }
        set
        {
            this._favorite_color = value;
        }
    }
    public virtual object Get(int fieldPos)
    {
        switch (fieldPos)
        {
            case 0: return this.name;
            case 1: return this.favorite_number;
            case 2: return this.favorite_color;
            default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
        };
    }
    public virtual void Put(int fieldPos, object fieldValue)
    {
        switch (fieldPos)
        {
            case 0: this.name = (string)fieldValue; break;
            case 1: this.favorite_number = (int)fieldValue; break;
            case 2: this.favorite_color = (string)fieldValue; break;
            default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
        };

    }

}