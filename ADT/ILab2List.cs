using System;

namespace ADT 
{
    public interface ILab2List<T>
    {
        /// <summary>
        /// Lägger till ett värde i början av listan.
        /// </summary>
        /// <param name="data">Det värde som ska läggas till.</param>
        void AddFirst(T data);
        
        /// <summary>
        /// Lägger till ett värde i slutet av listan.
        /// </summary>
        /// <param name="data">Det värde som ska läggas till.</param>
        void AddLast(T data);

        /// <summary>
        /// Lägger till ett värde vid index
        /// </summary>
        /// <param name="index">Vid vilket index vi vill lägga till.</param>
        /// <param name="data">Det värde som ska läggas till.</param>
        void AddAt(int index, T data);
        
        /// <summary>
        /// Returnerar antal element i listan
        /// </summary>
        /// <returns>Antal element det finns i listan</returns>
        int Count();
        
        /// <summary>
        /// Returnerar index på det element vi skickar in
        /// Om target inte finns i listan returnerar vi -1
        /// </summary>
        /// <param name="target">Elementet vi letar efter</param>
        /// <returns>Index på target</returns>
        int IndexOf(T target);

        /// <summary>
        /// Förskjuter listans värden från och med plats index, med ett steg
        /// mot listans slut.Därefter sätts värdet data på den plats som
        /// överensstämmer med index. Om i är utanför intervallet [0, Count()[
        /// kastas IndexOutOfRangeException.
        /// </summary>
        /// <param name="i">Index till platsen för insättning av data</param>
        /// <param name="data">Det värde som ska sättas in</param>
        void Insert(int index, T data);
        
        /// <summary>
        /// Tar bort det värde som överenstämmer med target
        /// Om värdet saknas i listan returneras false
        /// annars true.
        /// </summary>
        /// <param name="target">Det elementet som ska plockas bort.</param>
        /// <returns>True/False beroende på om värdet plockats bort</returns>
        bool Remove(T target);
        
        /// <summary>
        /// Tar bort det värde som finns på den plats som överenstämmer
        /// med index i. Därefter förskjuts alla värden efter som följer
        /// efter det bortagna värdet ett steg mot listans början. Om i är
        /// utanför intervallet [0, Count()[ kastas IndexOutOfRangeException.
        /// </summary>
        /// <param name="i">Index till det värde som ska tas bort.</param>
        bool Remove(int index);

        /// <summary>
        /// Gör det möjligt att använda fält-notation mot listan. Det vill
        /// säga komma åt de värden som finns i listan på motsvarande sätt
        /// som för en array. Redan inlagda värden kan uppdateras, men nya
        /// värden går inte att lägga till och värden kan inte tas bort. Om i
        /// är utanför intervallet [0, Count()] kastas IndexOutOfRangeException.
        /// Mer information om indexerare finns på följande adress:
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
        /// </summary>
        /// <param name="i">Index för det värde som du vill få tillgång till</param>
        /// <returns>Det värde som finns på platsen med indexet i</returns>
        T this[int i] { get; set; }

        /// <summary>
        /// Kopierar listans alla värden till en array och returnerar den.
        /// </summary>
        /// <returns>En array med kopior av alla listans alla värden</returns>
        T[] ToArray();
    }
}
