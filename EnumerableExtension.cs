namespace EnumerableBenchmarks
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Generic Divide Large Group into Smaller Ones with Size = chunkSize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bigGroup"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Divide<T>(this IEnumerable<T> bigGroup, int chunkSize)
        {
            if (bigGroup == null)
            {
                throw new NullReferenceException();
            }

            if (chunkSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bigGroup), "variable needs to be greater than 1");
            }

            while (bigGroup.Any())
            {
                yield return bigGroup.Take(chunkSize);
                bigGroup = bigGroup.Skip(chunkSize);
            }
        }
    }
}
