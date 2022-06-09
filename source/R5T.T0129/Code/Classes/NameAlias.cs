using System;


namespace R5T.T0129
{
    /// <summary>
    /// Represents an alias from one name to another.
    /// </summary>
    /// <remarks>
    /// <para>While this class was generated for working with C# code syntax name alias using declarations, it can be used more broadly since its source- and destination-names are of string type.</para>
    /// Notes:
    /// <para>* The name "Name" was chosen (as opposed to "name expression") to allow for general use with any type of name.</para>
    /// <para>* Class instead of struct: even though this class is small, it is frequently copied from function to function and it is assumed there are few instances of it. Thus the overhead of frequently copying the data is avoided by being a reference type instead of a value type.</para>
    /// <para>* Sealed for performance since this is just a basic data type.</para>
    /// Also see:
    /// * R5T.L0011.X000.NameAlias (specific to Roslyn C# code syntax)
    /// </remarks>
    public sealed class NameAlias : IEquatable<NameAlias>, IComparable<NameAlias>
    {
        #region Static

        public static NameAlias From(string destinationName, string sourceName)
        {
            var output = new NameAlias
            {
                DestinationName = destinationName,
                SourceName = sourceName,
            };

            return output;
        }

        public static bool operator ==(NameAlias left, NameAlias right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NameAlias left, NameAlias right)
        {
            return !(left == right);
        }

        // No "<" and ">" operators under the assumption we will instead always use comparisons to sort name aliases.

        #endregion


        /// <summary>
        /// The alias of the name.
        /// </summary>
        public string DestinationName { get; set; }
        /// <summary>
        /// The name being aliased.
        /// </summary>
        public string SourceName { get; set; }


        public NameAlias()
        {
        }

        public NameAlias(
            string destinationName,
            string sourceName)
        {
            this.DestinationName = destinationName;
            this.SourceName = sourceName;
        }

        public bool Equals(NameAlias other)
        {
            var output = other is object
                && this.DestinationName == other.DestinationName
                && this.SourceName == other.SourceName
                ;

            return output;
        }

        public override bool Equals(object obj)
        {
            var output = this.Equals(obj as NameAlias);
            return output;
        }

        public override int GetHashCode()
        {
            // Use both destination name and source name since for a general name alias there might be multiple names aliased to the same name (as opposed to a code 
            var output = HashCode.Combine(
                this.DestinationName,
                this.SourceName);

            return output;
        }

        public int CompareTo(NameAlias other)
        {
            var otherIsNull = other is null;
            if(otherIsNull)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var destinationNameComparison = this.DestinationName.CompareTo(other.DestinationName);
            if (ComparisonHelper.IsNotEqualResult(destinationNameComparison))
            {
                return destinationNameComparison;
            }

            var sourceNameComparison = this.SourceName.CompareTo(other.SourceName);
            return sourceNameComparison;
        }

        public override string ToString()
        {
            var representation = $"{this.DestinationName} = {this.SourceName}";
            return representation;
        }
    }
}