using System;

namespace VectorNet
{
    /// <summary>
    /// Class representing a 3-dimensional vector of floats.
    /// </summary>
    /// <seealso cref="IEquatable{Vec3f}" />
    public struct Vec3f : IVec3<Vec3f, float>, IEquatable<Vec3f>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3f"/> struct.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        /// <param name="z">The z-axis value.</param>
        public Vec3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3f"/> struct.
        /// </summary>
        /// <param name="vector">The vector to copy.</param>
        public Vec3f(Vec3f vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        /// <summary>
        /// Gets the x-axis value.
        /// </summary>
        /// <value>
        /// The x-axis value.
        /// </value>
        public float X { get; }

        /// <summary>
        /// Gets the y-axis value.
        /// </summary>
        /// <value>
        /// The y-axis value.
        /// </value>
        public float Y { get; }

        /// <summary>
        /// Gets the z-axis value.
        /// </summary>
        /// <value>
        /// The z-axis value.
        /// </value>
        public float Z { get; }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        /// <value>
        /// The length of the vector.
        /// </value>
        public float Length => LengthOf(this);

        /// <summary>
        /// Gets the value at the specified index.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        /// <param name="i">The index.</param>
        /// <returns>The value at the index.</returns>
        public float this[int i]
        {
            get => GetValue(i);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Vec3d"/> to <see cref="Vec3f"/>.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator Vec3f(Vec3d vector)
            => new Vec3f((float)vector.X, (float)vector.Y, (float)vector.Z);

        /// <summary>
        /// Implements the '==' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static bool operator ==(Vec3f left, Vec3f right)
            => left.Equals(right);

        /// <summary>
        /// Implements the '!=' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static bool operator !=(Vec3f left, Vec3f right)
            => !left.Equals(right);

        /// <summary>
        /// Implements the binary '+' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3f operator +(Vec3f left, Vec3f right)
            => left.Add(right);

        /// <summary>
        /// Implements the unary '-' operator.
        /// </summary>
        /// <param name="vector">The vector to negate.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3f operator -(Vec3f vector)
            => -1 * vector;

        /// <summary>
        /// Implements the binary '-' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3f operator -(Vec3f left, Vec3f right)
            => left.Subtract(right);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3f operator *(float left, Vec3f right)
            => right.Scale(left);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3f operator *(Vec3f left, float right)
            => left.Scale(right);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static float operator *(Vec3f left, Vec3f right)
            => left.DotProduct(right);

        /// <summary>
        /// Adds the left and right vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3f Add(Vec3f left, Vec3f right)
            => new Vec3f(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z);

        /// <summary>
        /// Subtracts the left and right vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3f Subtract(Vec3f left, Vec3f right)
            => new Vec3f(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z);

        /// <summary>
        /// Scales the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        public static Vec3f Scale(Vec3f vector, float scalar)
            => new Vec3f(scalar * vector.X, scalar * vector.Y, scalar * vector.Z);

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="left">The left side of the dot product.</param>
        /// <param name="right">The right side of the dot product.</param>
        /// <returns>The dot product of two vectors.</returns>
        public static float DotProduct(Vec3f left, Vec3f right)
            => (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);

        /// <summary>
        /// Calculates the cross product of two vectors.
        /// </summary>
        /// <param name="left">The left side of the calculation.</param>
        /// <param name="right">The right side of the calculation.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vec3f CrossProduct(Vec3f left, Vec3f right)
            => new Vec3f(
                (left.Y * right.Z) - (left.Z * right.Y),
                (left.Z * right.X) - (left.X * right.Z),
                (left.X * right.Y) - (left.Y * right.X));

        /// <summary>
        /// Gets the length of a vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The length of the given vector.</returns>
        public static float LengthOf(Vec3f vector)
            => (float)Math.Sqrt(vector * vector);

        /// <summary>
        /// Transforms the vector to have a given length.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The desired length.</param>
        /// <returns>The given vector transformed to have the given length.</returns>
        public static Vec3f Resize(Vec3f vector, float length)
            => vector.Unit() * length;

        /// <summary>
        /// Gets the unit vector of the given vector.
        /// </summary>
        /// <param name="vector">The vector to get the unit vector for.</param>
        /// <returns>The unit vector of the given vector.</returns>
        public static Vec3f Unit(Vec3f vector)
            => vector * (1 / vector.Length);

        /// <summary>
        /// Copies the specified vector.
        /// </summary>
        /// <param name="vector">The vector to copy.</param>
        /// <returns>A copy of the original vector.</returns>
        public static Vec3f Copy(Vec3f vector)
            => new Vec3f(vector);

        /// <summary>
        /// Applies the selector on each value of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>A modified vector with the selector applied.</returns>
        public static Vec3f Apply(Vec3f vector, Func<float, float> selector)
            => new Vec3f(selector.Invoke(vector.X), selector.Invoke(vector.Y), selector.Invoke(vector.Z));

        /// <summary>
        /// Gets the value at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        /// The value at the index.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is not in range [0,2].</exception>
        public float GetValue(int index)
        {
            switch (index)
            {
                case 0: return X;
                case 1: return Y;
                case 2: return Z;
                default: throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Sets the value at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A new vector with the value at the index changed.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is not in range [0,2].</exception>
        public Vec3f SetValue(int index, float value)
        {
            switch (index)
            {
                case 0: return new Vec3f(value, Y, Z);
                case 1: return new Vec3f(X, value, Z);
                case 2: return new Vec3f(X, Y, value);
                default: throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Adds the given vector to the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>
        /// The resulting vector.
        /// </returns>
        public Vec3f Add(Vec3f other)
            => Add(this, other);

        /// <summary>
        /// Subtracts the given vector from the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>
        /// The resulting vector.
        /// </returns>
        public Vec3f Subtract(Vec3f other)
            => Subtract(this, other);

        /// <summary>
        /// Scales the vector by a given scalar.
        /// </summary>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        /// The scaled vector.
        /// </returns>
        public Vec3f Scale(float scalar)
            => Scale(this, scalar);

        /// <summary>
        /// Calculates the dot product between this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector..</param>
        /// <returns>
        /// The dot product of the two vectors.
        /// </returns>
        public float DotProduct(Vec3f other)
            => DotProduct(this, other);

        /// <summary>
        /// Calculates the cross product of this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>
        /// The resulting cross product.
        /// </returns>
        public Vec3f CrossProduct(Vec3f other)
            => CrossProduct(this, other);

        /// <summary>
        /// Transforms the vector to have the desired length.
        /// </summary>
        /// <param name="length">The desired length.</param>
        /// <returns>
        /// The vector transformed to have the desired length.
        /// </returns>
        public Vec3f Resize(float length)
            => Resize(this, length);

        /// <summary>
        /// Gets the unit vector of this vector.
        /// </summary>
        /// <returns>
        /// The unit vector of this vector.
        /// </returns>
        public Vec3f Unit()
            => Unit(this);

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns>
        /// A copy of this instance.
        /// </returns>
        public Vec3f Copy()
            => Copy(this);

        /// <summary>
        /// Applies the specified selector on each value.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns>
        /// A new vector with the values modified by the selector.
        /// </returns>
        public Vec3f Apply(Func<float, float> selector)
            => Apply(this, selector);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vec3f other)
            {
                return Equals(other);
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Vec3f other)
            => this.X == other.X && this.Y == other.Y && this.Z == other.Z;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
            => X.GetHashCode() * 2 * Y.GetHashCode() * 4 * Z.GetHashCode();

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
            => $"<{X}, {Y}, {Z}>";
    }
}
