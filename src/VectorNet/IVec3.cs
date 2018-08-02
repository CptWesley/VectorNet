using System;

namespace VectorNet
{
    /// <summary>
    /// Interface for three dimensional vectors.
    /// </summary>
    /// <typeparam name="TVec">Subclass being implemented.</typeparam>
    /// <typeparam name="T">Type of the class stored in the vector.</typeparam>
    public interface IVec3<TVec, T>
        where TVec : IVec3<TVec, T>
    {
        /// <summary>
        /// Gets the x-axis value.
        /// </summary>
        /// <value>
        /// The x-axis value.
        /// </value>
        T X { get; }

        /// <summary>
        /// Gets the y-axis value.
        /// </summary>
        /// <value>
        /// The y-axis value.
        /// </value>
        T Y { get; }

        /// <summary>
        /// Gets the z-axis value.
        /// </summary>
        /// <value>
        /// The z-axis value.
        /// </value>
        T Z { get; }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        /// <value>
        /// The length of the vector.
        /// </value>
        T Length { get; }

        /// <summary>
        /// Gets the value at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at the index.</returns>
        T GetValue(int index);

        /// <summary>
        /// Sets the value at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <returns>A new vector with the value at the index changed.</returns>
        TVec SetValue(int index, T value);

        /// <summary>
        /// Adds the given vector to the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting vector.</returns>
        TVec Add(TVec other);

        /// <summary>
        /// Subtracts the given vector from the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting vector.</returns>
        TVec Subtract(TVec other);

        /// <summary>
        /// Scales the vector by a given scalar.
        /// </summary>
        /// <param name="scalar">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        TVec Scale(T scalar);

        /// <summary>
        /// Calculates the dot product between this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector..</param>
        /// <returns>The dot product of the two vectors.</returns>
        T DotProduct(TVec other);

        /// <summary>
        /// Calculates the cross product of this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting cross product.</returns>
        TVec CrossProduct(TVec other);

        /// <summary>
        /// Transforms the vector to have the desired length.
        /// </summary>
        /// <param name="length">The desired length.</param>
        /// <returns>The vector transformed to have the desired length.</returns>
        TVec Resize(T length);

        /// <summary>
        /// Gets the unit vector of this vector.
        /// </summary>
        /// <returns>The unit vector of this vector.</returns>
        TVec Unit();

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        TVec Copy();

        /// <summary>
        /// Applies the specified selector on each value.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>A new vector with the values modified by the selector.</returns>
        TVec Apply(Func<T, T> selector);
    }
}
