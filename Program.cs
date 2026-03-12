const string DrinksTxtPath = $"..\\..\\..\\data\\drink.txt";
const string AsianTxtPath = $"..\\..\\..\\data\\asian.txt";

List<Nationality> nationalities = [];
List<PopulationGroup> populationGroups = [];
List<Citizen> citizens = [];

using StreamReader sr = new(DrinksTxtPath);
_ = sr.ReadLine();
int citId = 1;
while(!sr.EndOfStream)
{
    string[] tmp = sr.ReadLine().Split(';');

    int age = int.Parse(tmp[0]);
    bool isDrinking = tmp[1] == "Yes";
    int? drinkingWeekDays = tmp[2] == "NO" ? null : int.Parse(tmp[2]);
    int? drinkingWeekEnds = tmp[3] == "NO" ? null : int.Parse(tmp[3]);
    bool gender = tmp[4] == "Male";
    int natId = int.Parse(tmp[5]);
    Nationality nationlity = nationalities.SingleOrDefault(n => n.Id == natId);
    if (nationlity is null)
    {
        nationalities.Add(new()
        {
            Id = natId,
            Name = tmp[6],
        });
        nationlity = nationalities.Last();
    }
    string netIncomeString = tmp[7];

    int popId = int.Parse(tmp[8]);

    PopulationGroup populationGroup = populationGroups.SingleOrDefault(pg => pg.Id == popId);
    if (populationGroup is null)
    {
        populationGroups.Add(new()
        {
            Id = popId,
            Name = tmp[9],
        });
        populationGroup = populationGroups.Last();
    }
    string schoolDropout = tmp[10];
    string state = tmp[11];
    bool isTreated = tmp[12] == "1";


    citizens.Add(new(id: citId, age, isDrinking, drinkingWeekDays, drinkingWeekEnds, gender, nationlity, netIncomeString, populationGroup, schoolDropout, state, isTreated));

    citId++;
}

// Console.WriteLine($"nuber of citizens: {citizens.Count}");

for (int i = 0; i < 5; i++) Console.WriteLine(citizens[i]+"\n");

var f6a = citizens.Where(
    c => c.IsDrinking
    && c.Nationality.Name == "Birthright citizen"
    && c.State == "Florida"
    && c.Gender
    && c.NetIncome.Min is not null
    && c.NetIncome.Max is not null);

Console.WriteLine("-----------------");

foreach (var citizen in f6a) Console.WriteLine(citizen+"\n");

var f6b = f6a.Min(c => c.NetIncome.Min);

Console.WriteLine($"a leszurt allampolgarok minimalis jovedelme: {f6b} USD");


var f7 = citizens.Where(
    c => c.Age >= 18 && c.Age <= 65 
    && c.PopulationGroup.Name == "Asian" 
    && c.IsDrinking);

using StreamWriter sw = new(AsianTxtPath);

foreach (var citizen in f7) sw.WriteLine($"{citizen.Age},{citizen.State},{citizen.SchoolDropout}");

Console.WriteLine($"{AsianTxtPath} kész!");

//nexttime ->
//LINQ(!!!)
//using statement
//top lvl calling
//switch expression
//lambda
//is / is not
//naming convention