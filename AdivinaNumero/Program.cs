
string? jugador;
Random random = new Random();

int intentos = 0;
int puntajeMasAlto = 0;


Console.WriteLine("Adivina el Numero");

IniciarJuego();


void IniciarJuego()
{

    Console.WriteLine("Hola Bienvenido al Juego...");
    Console.WriteLine("Cual es tu Nombre");
   
    var nuevoRandom = random.Next(1, 10);

     jugador = Console.ReadLine();
    quererJugar( nuevoRandom);
}



void quererJugar( int nuevoRandom , bool jugarNuevo = false) {

    if(!jugarNuevo)
        Console.WriteLine($"Hola {jugador} , estas listo? (Ingrese Si/No)");
    else

        Console.WriteLine($"{jugador} , estas listo para jugar de nuevo? (Ingrese Si/No)");

    var quiereJugar = Console.ReadLine();

    //el signo ? es para validar si la variable tiene algo guardado.
    switch (quiereJugar?.ToLower().Trim())
    {
        case "si":

            Jugar( nuevoRandom);
            break;

        case "no":

            noJugar();
            break;



        default:
            Console.WriteLine("Esta no es una opcion válida");
            quererJugar( nuevoRandom);
            break;
    }


}

void Jugar(int nuevoRandom) {

    

    try
    {

        Console.WriteLine("ingrese un número entre  1 y 10");

        var numeroElegido = Console.ReadLine();

        if (numeroElegido is null)
            throw new Exception("Necesitas ingresar un numero");

        if (int.Parse(numeroElegido) < 1 || int.Parse(numeroElegido) > 10)
            throw new Exception("Por favor ingrese un numero entre  1 y 10");

        if(int.Parse(numeroElegido) == nuevoRandom)
        {
            Adivinaste();
            
        }else if(int.Parse(numeroElegido) < nuevoRandom)
        {
            Console.WriteLine("Intenta nuevamente! el numero es mayor...");
            intentos++;
            Jugar(nuevoRandom);
        }else if (int.Parse(numeroElegido) > nuevoRandom)
        {
            Console.WriteLine("Intenta nuevamente! el numero es menor...");
            intentos++;
            Jugar(nuevoRandom);
        }
    }
    catch (Exception e)
    {

        Console.WriteLine($"Ha ocurrido un error {e.Message}");
        Jugar(nuevoRandom);
    }


}


void noJugar()
{
    Console.WriteLine("No te preocupes, Gracias por jugar");

}

void Adivinaste()
{
    Console.WriteLine("Genial! Adivinaste el número");
    intentos++;

    if (puntajeMasAlto == 0 || intentos < puntajeMasAlto)
        puntajeMasAlto = intentos;

    Console.WriteLine($"le tomó {intentos} intentos para adivinar el número");
    mostrarIntentoMasAlto();
    intentos = 0;
    var nuevoRandom = random.Next(1, 10);

    quererJugar( nuevoRandom, true);

}


void mostrarIntentoMasAlto()
{
    if (puntajeMasAlto == 0)
        Console.WriteLine("Actualmente no hay puntaje más alto, es tu oportunidad");
    else
        Console.WriteLine($"El puntaje más alto tiene {puntajeMasAlto} puntos");
}