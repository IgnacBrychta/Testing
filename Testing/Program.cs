using Testing;

/*
 * Toto je simulátor řídícího programu pro elektrárnu na domě.
 * Simulace běží po hodinách (celkem 10 hodin) a v každé hodině elektrátna vyprodukuje 0-5kW (podle počasí)
 * V tuto chvíli se veškerá el. energie prodá do sítě.
 * Zkuste si program spustit a sledovat, jestli je to opravdu tak (pokud Vám interval zobrazování přijde dlouhý, klidně si ho snižte)
 * 
 * Nyní si program pořádně prostudujte. 
 * Jakmile se budete cítit připraveni na první zadání, přečtěte si toto:
 *   https://gitlab.com/school9961818/testing/-/blob/master/Testing.md
 */

for (int i = 0; i < 20; i++)
{
    decimal plantOutput = new Random().Next(3000, 5000) / 1000m; // výkon v kW
    decimal Household = new Random().Next(500, 7000) / 1000m;

    
    DistributionModel distribution = PlantHelpers.HandlePlantOutput(plantOutput, Household, true);

    // následující plný zápis podmínky...

    string gridFlow;
    if (distribution.Grid > 0)
    {
        gridFlow = "--->";
    }
    else
    {
        gridFlow = "<---";
    }

    // se dá zkrátit do jednoho příkazu pomocí "?"
    string batteryFlow = distribution.Battery > 0 ? "--->" : "<---";

    Console.WriteLine($"Hour {i+1}");
    Console.WriteLine($"Plant output       : {plantOutput} kW");
    Console.WriteLine($"House consumption  : {distribution.Household} kW");
    
    Console.WriteLine($"\nGrid               : {gridFlow} : {distribution.Grid} kW");
    
    Console.WriteLine($"\nBattery            : {batteryFlow} : {distribution.Battery} kW");
    Console.WriteLine($"Battery SoC        : {distribution.BatteryStateOfCharge}%");
    Console.WriteLine($"Charge consumption : {distribution.CarCharger} kW");
    if (PlantHelpers.gridFailure) Console.WriteLine("GRID FAILURE");
    Thread.Sleep(3000); // počkej 3  sekundy 
    Console.Clear();
}

/*
 * 1. Připojte domácnost.
 * Upravte simulaci tak, aby každou hodinu generovala náhodnou spotřebu domácnosti (0.5 - 7.0 kW).
 * Tuto spotřebu předávejte metodě HandlePlantOutput.
 * Upravte metodu tak, aby spotřebu reflektovala.
 *  Příklad: 
 *    Plant output: 2, Household: 1 -> Grid: 1 kW, Household consumption: 1kW
 *    Plant output: 2, Household: 3 -> Grid: -1 kW, Household consumption: 3kW
 * Po úpravě metody by Vám měly procházet první tři testy.
 * Pokud ano, proveďte commit: 
 *   https://gitlab.com/school9961818/testing/-/blob/master/Commit.md
 */
  // HOTOVO




/*
 * 2. Připojte baterku.
 * Upravte simulaci tak, aby používala baterii. 
 * Baterie bude začínat na 50% nabití (batteryStateOfCharge).
 * Kapacita baterie je 10kW.
 * Baterie nemá omezení vybíjení nebo nabíjení. Za hodinu ji můžeme celou nabít i vybít.
 * Upravte metodu tak, aby baterii reflektovala 
 *   První nabíjíme baterku, teprve pak prodáváme do sítě
 *   První bereme energii z baterky, teprve pak dokupujeme ze sítě
 *  Příklad: 
 *    Plant output: 2, Household: 1, battery SoC: 50 -> Grid: 0 kW, Household consumption: 1kW, battery: 1kW, battery Soc: 60
 * Po úpravě metody by Vám měly procházet prvních šest testů.
 * Pokud ne, přečtěte si toto: 
 *   https://gitlab.com/school9961818/testing/-/blob/master/Debugging.md
 * Prochází 6 testů? Proveďte commit
 */


/*
 * 3. Nabíječka na auto.
 * Upravte simulaci tak, aby používala nabíječku na auto. 
 * Nabíječka má výkon 9.5kW.
 * Upravte metodu tak, aby se nabíječka spouštěla jen v případě, že je baterie nabitá alespoň na 80%. 
 * Po úpravě by Vám měly procházet všechny testy.
 * Proveďte commit.
 * Založte novou branch, pushněte a založte merge request.
 *   https://gitlab.com/school9961818/testing/-/blob/master/MR.md
 */


/*
 * BONUS: Upravte metodu tak, aby nabíječka na auto nikdy netahala ze sítě.
 * Budete muset upravit parametry posledního testu.
 * Doporučuji přidat ještě test nebo dva.
 */