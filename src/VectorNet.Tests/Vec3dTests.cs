using Xunit;

using static AssertNet.Xunit.Assertions;

namespace VectorNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="Vec3d"/> class.
    /// </summary>
    public class Vec3dTests
    {
        private Vec3d _v = new Vec3d(1, 1, 1);

        /// <summary>
        /// Checks that a vector is equal to itself.
        /// </summary>
        [Fact]
        public void EqualsSameTest()
        {
            AssertThat(_v).IsEqualTo(_v);
            AssertThat(_v.GetHashCode()).IsEqualTo(_v.GetHashCode());
        }

        /// <summary>
        /// Checks that a vector is equal to a copy of itself.
        /// </summary>
        [Fact]
        public void EqualsCopyTest()
        {
            AssertThat(_v).IsEqualTo(_v.Copy());
            AssertThat(_v.GetHashCode()).IsEqualTo(_v.Copy().GetHashCode());
        }

        /// <summary>
        /// Checks that the vector is not equal to null.
        /// </summary>
        [Fact]
        public void DoesNotEqualNullTest()
            => AssertThat(_v).IsNotEqualTo(null);

        /// <summary>
        /// Checks that a vector is not considered equal when the x-axis value differs.
        /// </summary>
        [Fact]
        public void DoesNotEqualDifferentXTest()
            => AssertThat(_v).IsNotEqualTo(new Vec3d(0, 1, 1));

        /// <summary>
        /// Checks that a vector is not considered equal when the y-axis value differs.
        /// </summary>
        [Fact]
        public void DoesNotEqualDifferentYTest()
            => AssertThat(_v).IsNotEqualTo(new Vec3d(1, 0, 1));

        /// <summary>
        /// Checks that a vector is not considered equal when the z-axis value differs.
        /// </summary>
        [Fact]
        public void DoesNotEqualDifferentZTest()
            => AssertThat(_v).IsNotEqualTo(new Vec3d(1, 1, 0));

        /// <summary>
        /// Checks that additions are calculated correctly.
        /// </summary>
        [Fact]
        public void AdditionTest()
            => AssertThat(_v + _v).IsEqualTo(new Vec3d(2, 2, 2));

        /// <summary>
        /// Checks that subtractions are calculated correctly.
        /// </summary>
        [Fact]
        public void SubtractionTest()
            => AssertThat(_v - _v).IsEqualTo(new Vec3d(0, 0, 0));

        /// <summary>
        /// Checks that the unary '-' operator works correctly.
        /// </summary>
        [Fact]
        public void UnaryMinusTest()
            => AssertThat(-_v).IsEqualTo(new Vec3d(-1, -1, -1));

        /// <summary>
        /// Checks that scaling works accordingly.
        /// </summary>
        [Fact]
        public void ScaleTest()
        {
            AssertThat(_v * 3).IsEqualTo(new Vec3d(3, 3, 3));
            AssertThat(-6 * _v).IsEqualTo(new Vec3d(-6, -6, -6));
        }

        /// <summary>
        /// Checks that the dot product is calculated correctly.
        /// </summary>
        [Fact]
        public void DotTest()
            => AssertThat(_v * _v).IsEqualTo(3);

        /// <summary>
        /// Checks that the cross product gets calculated correctly.
        /// </summary>
        [Fact]
        public void CrossProductTest()
            => AssertThat(new Vec3d(1, 2, 3).CrossProduct(new Vec3d(1, 5, 7))).IsEqualTo(new Vec3d(-1, -4, 3));

        /// <summary>
        /// Checks that we can correctly calculate the length of a vector.
        /// </summary>
        [Fact]
        public void LengthTest()
            => AssertThat(new Vec3d(13, 0, 0).Length).IsEqualTo(13);

        /// <summary>
        /// Checks if the found unit vector is correct.
        /// </summary>
        [Fact]
        public void UnitTest()
        {
            AssertThat(new Vec3d(100, 0, 0).Unit()).IsEqualTo(new Vec3d(1, 0, 0));
            AssertThat(new Vec3d(1, 2, 3).Unit().Length).IsEqualTo(1);
        }

        /// <summary>
        /// Checks that implicit conversion from <see cref="Vec3f"/> to <see cref="Vec3d"/> works correctly.
        /// </summary>
        [Fact]
        public void FromVec3fTest()
            => AssertThat(new Vec3d(new Vec3f(1, 1, 1))).IsEqualTo(_v);
    }
}
