namespace MaxLib.Ini
{
    /// <summary>
    /// This mode describes how byte[] are displayed as a string
    /// </summary>
    public enum BinaryMode
    {
        /// <summary>
        /// All bytes are encoded as Base 64
        /// </summary>
        Base64,
        /// <summary>
        /// All bytes are encoded in hexadecimal format `0-f`.
        /// The order of the nibbles is first high, then low
        /// (0x10 = "10").
        /// </summary>
        Hex
    }
}