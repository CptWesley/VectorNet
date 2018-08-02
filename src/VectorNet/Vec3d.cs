using System;

namespace VectorNet
{
    /// <summary>
    /// Class representing a 3-dimensional vector of doubles.
    /// </summary>
    /// <seealso cref="IEquatable{Vec3d}" />
    public struct Vec3d : IEquatable<Vec3d>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3d"/> struct.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        /// <param name="z">The z-axis value.</param>
        public Vec3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vec3d"/> struct.
        /// </summary>
        /// <param name="vector">The vector to copy.</param>
        public Vec3d(Vec3d vector)
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
        public double X { get; }

        /// <summary>
        /// Gets the y-axis value.
        /// </summary>
        /// <value>
        /// The y-axis value.
        /// </value>
        public double Y { get; }

        /// <summary>
        /// Gets the z-axis value.
        /// </summary>
        /// <value>
        /// The z-axis value.
        /// </value>
        public double Z { get; }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        /// <value>
        /// The length of the vector.
        /// </value>
        public double Length => LengthOf(this);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Vec3f"/> to <see cref="Vec3d"/>.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vec3d(Vec3f vector)
            => new Vec3d(vector.X, vector.Y, vector.Z);

        /// <summary>
        /// Implements the '==' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static bool operator ==(Vec3d left, Vec3d right)
            => left.Equals(right);

        /// <summary>
        /// Implements the '!=' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static bool operator !=(Vec3d left, Vec3d right)
            => !left.Equals(right);

        /// <summary>
        /// Implements the binary '+' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3d operator +(Vec3d left, Vec3d right)
            => left.Add(right);

        /// <summary>
        /// Implements the unary '-' operator.
        /// </summary>
        /// <param name="vector">The vector to negate.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3d operator -(Vec3d vector)
            => -1 * vector;

        /// <summary>
        /// Implements the binary '-' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3d operator -(Vec3d left, Vec3d right)
            => left.Subtract(right);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3d operator *(double left, Vec3d right)
            => right.Scale(left);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static Vec3d operator *(Vec3d left, double right)
            => left.Scale(right);

        /// <summary>
        /// Implements the '*' operator.
        /// </summary>
        /// <param name="left">The left side of the operation.</param>
        /// <param name="right">The right side of the operation.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static double operator *(Vec3d left, Vec3d right)
            => left.DotProduct(right);

        /// <summary>
        /// Adds the left and right vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3d Add(Vec3d left, Vec3d right)
            => new Vec3d(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z);

        /// <summary>
        /// Subtracts the left and right vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3d Subtract(Vec3d left, Vec3d right)
            => new Vec3d(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z);

        /// <summary>
        /// Scales the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        public static Vec3d Scale(Vec3d vector, double scalar)
            => new Vec3d(scalar * vector.X, scalar * vector.Y, scalar * vector.Z);

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="left">The left side of the dot product.</param>
        /// <param name="right">The right side of the dot product.</param>
        /// <returns>The dot product of two vectors.</returns>
        public static double DotProduct(Vec3d left, Vec3d right)
            => (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);

        /// <summary>
        /// Calculates the cross product of two vectors.
        /// </summary>
        /// <param name="left">The left side of the calculation.</param>
        /// <param name="right">The right side of the calculation.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vec3d CrossProduct(Vec3d left, Vec3d right)
            => new Vec3d(
                (left.Y * right.Z) - (left.Z * right.Y),
                (left.Z * right.X) - (left.X * right.Z),
                (left.X * right.Y) - (left.Y * right.X));

        /// <summary>
        /// Gets the length of a vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The length of the given vector.</returns>
        public static double LengthOf(Vec3d vector)
            => Math.Sqrt(vector * vector);

        /// <summary>
        /// Transforms the vector to have a given length.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The desired length.</param>
        /// <returns>The given vector transformed to have the given length.</returns>
        public static Vec3d Resize(Vec3d vector, double length)
            => vector.Unit() * length;

        /// <summary>
        /// Gets the unit vector of the given vector.
        /// </summary>
        /// <param name="vector">The vector to get the unit vector for.</param>
        /// <returns>The unit vector of the given vector.</returns>
        public static Vec3d Unit(Vec3d vector)
            => vector * (1 / vector.Length);

        /// <summary>
        /// Copies the specified vector.
        /// </summary>
        /// <param name="vector">The vector to copy.</param>
        /// <returns>A copy of the original vector.</returns>
        public static Vec3d Copy(Vec3d vector)
            => new Vec3d(vector);

        /// <summary>
        /// Adds the given vector to the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting vector.</returns>
        public Vec3d Add(Vec3d other)
            => Add(this, other);

        /// <summary>
        /// Subtracts the given vector from the current vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting vector.</returns>
        public Vec3d Subtract(Vec3d other)
            => Subtract(this, other);

        /// <summary>
        /// Scales the vector by a given scalar.
        /// </summary>
        /// <param name="scalar">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        public Vec3d Scale(double scalar)
            => Scale(this, scalar);

        /// <summary>
        /// Calculates the dot product between this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector..</param>
        /// <returns>The dot product of the two vectors.</returns>
        public double DotProduct(Vec3d other)
            => DotProduct(this, other);

        /// <summary>
        /// Calculates the cross product of this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The resulting cross product.</returns>
        public Vec3d CrossProduct(Vec3d other)
            => CrossProduct(this, other);

        /// <summary>
        /// Transforms the vector to have the desired length.
        /// </summary>
        /// <param name="length">The desired length.</param>
        /// <returns>The vector transformed to have the desired length.</returns>
        public Vec3d Resize(double length)
            => Resize(this, length);

        /// <summary>
        /// Gets the unit vector of this vector.
        /// </summary>
        /// <returns>The unit vector of this vector.</returns>
        public Vec3d Unit()
            => Unit(this);

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public Vec3d Copy()
            => Copy(this);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vec3d other)
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
        public bool Equals(Vec3d other)
            => this.X == other.X && this.Y == other.Y && this.Z == other.Z;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
            => X.GetHashCode() * 2 * Y.GetHashCode() * 4 * Z.GetHashCode();
    }
}
