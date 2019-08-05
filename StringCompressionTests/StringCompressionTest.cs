using NUnit.Framework;
using Shouldly;
using System.Text;

namespace StringCompressionTests
{
    [TestFixture]
    public class StringCompressionTest
    {
        [Test]
        public void Should_return_type_string()
        {
            var result = Compression.Run("s");
            result.ShouldBeAssignableTo<string>();
        }


        [Test]
        [TestCase("Simon")]
        [TestCase("John")]
        public void Should_return_copy_of_input(string input)
        {
            var result = Compression.Run(input);

            result.ShouldBe(input);

        }

        [Test]
        [TestCase("sssss", "s5")]
        [TestCase("iiiiii", "i6")]
        public void Should_return_letter_and_number_of_occurancies(string input, string output)
        {
            var result = Compression.Run(input);
            result.ShouldBe(output);
        }
        [Test]
        [TestCase("siimon", "si2mon")]
        [TestCase("simmmon", "sim3on")]
        public void Should_return_letter_and_number_of_occurancies_in_string(string input, string output)
        {
            var result = Compression.Run(input);
            result.ShouldBe(output);
        }

    }

    public class Compression
    {
        public static string Run(string input)
        {

            var builder = new StringBuilder();
            var inputArray = input.ToCharArray();
            var counter = 1;

            for (var i = 0; i <= inputArray.Length - 1; i++)
            {

                if (i == inputArray.Length - 1)
                {

                    builder.Append(inputArray[i]);

                    if (counter > 1)
                    {
                        builder.Append(counter);
                    }

                    break;
                }


                if (inputArray[i] == inputArray[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (counter > 1)
                    {
                        builder.Append(inputArray[i]);
                        builder.Append(counter);
                        counter = 1;
                    }
                    else
                    {
                        builder.Append(inputArray[i]);
                    }
                }

            }

            return builder.ToString();
        }
    }
}