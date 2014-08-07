namespace AwesomeComputers.MotherBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMotherboard 
    { 
        /// <summary>
        /// The motherboard loads value from the RAM of the computer and stores it in his property
        /// untill it is needed for future use.
        /// </summary>
        /// <returns>Returns the loaded value</returns>
        int LoadRamValue(); 

        /// <summary>
        /// The motherboard save int value to the Ram of the computer
        /// </summary>
        /// <param name="value">The value to be saved in the RAM of the computer</param>
        void SaveRamValue(int value); 

        /// <summary>
        /// The motherboard can communicate with the video card and send string data that needs to be drawn from the videoCard
        /// </summary>
        /// <param name="data">The string value that needs to be drawn from the videoCard</param>
        void DrawOnVideoCard(string data);
    }
}
