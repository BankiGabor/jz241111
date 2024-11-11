namespace jz241111;

internal class Fish
{
    private int top;
    private int depth;
    private float weight;
    private bool weightIsSet = false;
    private string species;

    public float Weight
    {
        get => weight; 
        set
        {
            if (value < 0.5 || value > 40)
                throw new Exception($"hibás érték: Weight := {value}\nhiba, a Weight érték [0.5; 40] intervallumon belül valid");

            if (weightIsSet && (value < weight*0.9 || value > weight*1.1 ))
                throw new Exception($"a Weight régi értéke: {weight}\na beállítani kívánt érték: {value}\nhiba, a Weight érték nem változhat nagyobbat, mint az aktuális érték 10%-a");

            weight = value;
            weightIsSet = true;
        }
    }
    public bool Predator { get; }
    public int Top
    {
        get => top;
        set
        {
            if (value < 0 || value > 400) 
                throw new Exception($"hibás érték: Top := {value}\nhiba, a Top érték [0; 400] intervallumon belül valid");
            top = value;
        }
    }
    public int Depth
    {
        get => depth; set
        {
            if (value < 10 || value > 400) 
                throw new Exception($"hibás érték: Depth := {value}\nhiba, a Depth érték [10; 400] intervallumon belül valid");
            depth = value;
        }
    }
    public string Species
    {
        get => species; 
        set
        {
            if (value is null)
                throw new NullReferenceException("A Species nem vehet fel null értéket");

            if (value.Length < 3 || value.Length > 30)
                throw new Exception($"a kapott érték({value}) nem felel meg a kritériumoknak\nA Species string hossza [3, 30] között kell lennie");
            species = value;
        }
    }

    public override string ToString()
    {
        return $"{Species} ({(Predator ? "carnivore" : "herbivore")}) [{Top} - {Top + Depth} cm] {Weight:0.0} kg";
    }

    public Fish(float weight, bool predator, int top, int depth, string species)
    {
        Weight = weight;
        Predator = predator;
        Top = top;
        Depth = depth;
        Species = species ?? throw new ArgumentNullException(nameof(species));
    }
}
