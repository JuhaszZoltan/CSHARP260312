class Citizen(int id, int age, bool isDrinking, int? drinkingWeekdays, int? drinkingWeekends, bool gender, Nationality nationality, string netIncomeString, PopulationGroup populationGroup, string schoolDropout, string state, bool isTreated)
{
    public int Id { get; set; } = id;
    public int Age { get; set; } = age;
    public bool IsDrinking { get; set; } = isDrinking;
    public int? DrinkingWeekDays { get; set; } = drinkingWeekdays;
    public int? DrinkingWeekEnds { get; set; } = drinkingWeekends;
    public bool Gender { get; set; } = gender;
    public Nationality Nationality { get; set; } = nationality;
    public (int? Min, int? Max) NetIncome
    {
        get
        {
            if (NetIncomeString == "Unknown" || NetIncomeString == "Refused") return (null, null);
            if (NetIncomeString == "Under 1800") return (null, 1800);
            if (NetIncomeString == "Above 32400") return (32400, null);
            string[] tmp = NetIncomeString.Split(" to ");
            return (int.Parse(tmp[0]), int.Parse(tmp[1]));
        }
    }
    private string NetIncomeString { get; set; } = netIncomeString;
    public PopulationGroup PopulationGroup { get; set; } = populationGroup;
    public string SchoolDropout { get; set; } = schoolDropout;
    public string State { get; set; } = state;
    public bool IsTreated { get; set; } = isTreated;

    public float? AverageDrinking
    {
        get
        {
            if (DrinkingWeekDays is null || DrinkingWeekEnds is null) return null;
            return (DrinkingWeekDays * 5 + DrinkingWeekEnds * 2) / 7F;
        }
    }
    public override string ToString() =>
        $"\tCitizen ID: {Id}\n" +
        $"\tAge: {Age}\n" +
        $"\tDrinking: {(IsDrinking ? "YES" : "NO")}\n" +
        $"\tDrinking on weekdays: {(DrinkingWeekDays is null ? "NO" : $"{DrinkingWeekDays} cl")}\n" +
        $"\tDrinking on weekends: {(DrinkingWeekEnds is null ? "NO" : $"{DrinkingWeekEnds} cl")}\n" +
        $"\tGender: {(Gender ? "Male" : "Female")}\n" +
        $"\tNationality: {Nationality.Name}\n" +
        $"\tNet income: {NetIncomeString} {(NetIncome.Min.HasValue || NetIncome.Max.HasValue ? "USD" : "")}\n" +
        $"\tPopulation group: {PopulationGroup.Name}\n" +
        $"\tDrop out from schoole: {SchoolDropout}\n" +
        $"\tState: {State}\n" +
        $"\tTreated: {(IsTreated ? "YES" : "NO")}\n" +
        $"\tAverage drinking: {(AverageDrinking is null ? "NaN" : $"{AverageDrinking:0.00} lc")}";
}