using UnityEngine;
// Rajapinnan tiedoston (ja itse rajapinnan) nimi alkaa
// aina isolla I kirjaimella.
namespace Mobiiliesimerkki
{
    /// <summary>
    /// Rajapinta, joka määrittelee liikkumisen toiminnallisuuden.
    /// </summary>
    public interface IMover
    {
        /// <summary>
        /// Liikkumisnopeus.
        /// </summary>
        float Speed { get; }
        /// <summary>
        /// Liikuttaa peliobjektia annetuun suuntaan.
        /// </summary>
        /// <param name="movement">Liikkumisen suunta.</param>
        void Move(Vector2 movement);
    }
}