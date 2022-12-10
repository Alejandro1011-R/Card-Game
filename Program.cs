
static List<int> Orden(List<int> cartas)
 {
    Random rnd = new Random();
    List<int> orden = new List<int>();
    int i = 0;
    while (i < cartas.Count)                                   //Método para perartir aleatoriamente las cartas
    {
        int carta = rnd.Next(0, cartas.Count);
        if (!orden.Contains(cartas[carta]))
        {
            orden.Add(cartas[carta]);
            i++;
        }
    }
    return orden;
 }
