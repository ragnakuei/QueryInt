using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

namespace QueryInt
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestRunner>();
        }
    }

    [CoreJob] // 可以針對不同的 CLR 進行測試
    [MinColumn, MaxColumn]
    [MemoryDiagnoser]
    public class TestRunner
    {
        private readonly TestClass _test = new TestClass();

        public TestRunner()
        {
        }

        [Benchmark]
        public void ListTest() => _test.ListTest();

        [Benchmark]
        public void ArrayTest() => _test.ArrayTest();

        [Benchmark]
        public void DictionaryTest() => _test.DictionaryTest();
    }

    public class TestClass
    {
        private readonly List<Int32>          li  = new List<Int32>(1000);
        private readonly Dictionary<int, int> di  = new Dictionary<int, int>(1000);
        private readonly int[]                arr = new int[1000];
        
        public TestClass()
        {
            for (int i = 0; i < 1000; i++)
            {
                li.Add(i);
                di.Add(i, i);
                arr[i] = i;
            }
        }

        public void ListTest()
        {
            var a = li[700];
        }

        public void ArrayTest()
        {
            var a = li[700];
        }

        public void DictionaryTest()
        {
            var a = li[700];
        }
    }

}
