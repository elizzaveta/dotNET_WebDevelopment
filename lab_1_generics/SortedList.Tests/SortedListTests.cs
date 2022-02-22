using System;
using NUnit.Framework;
using FluentAssertions;
using SortedList_Library;


namespace SortedList.Tests
{
    public class Tests
    {
        [Test]
        public void MySortedList_NewSortedListContainsZeroElems()
        {
            //Arrange + Act
            var list = new MySortedList<int>();
            
            // Assert
            list.Count.Should().Be(0);
        }
        
        [Test]
        [TestCase(new [] {3, 1})]
        [TestCase(new [] {21, 55, 8, 62, 16})]
        public void MySortedList_NotEmptySortedListCountGreaterThanZero(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            
            // Assert
            list.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void MySortedList_IsReadOnly()
        {
                        
            // Arrange + Act 
            var list = new MySortedList<int>();
            
            // Assert
            list.IsReadOnly.Should().BeFalse();
        }

        [Test]
        [TestCase(5)]
        public void MySortedList_ElemIndexZeroOfOneElemListIsElem(int elem)
        {
            // Arrange
            var list = new MySortedList<int>();
            // Act 
            list.Add(elem);
            // Assert
            list[0].Should().Be(elem);
        }

        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_CountOfElemsAfterClearIsZero(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            list.Clear();
            
            // Assert
            list.Count.Should().Be(0);
        }

        [Test]
        public void MySortedList_EmptyListContainsAnyElemIsFalse()
        {
            // Arrange +  Act 
            var list = new MySortedList<int>();
            
            // Assert
            list.Contains(9).Should().BeFalse();
        }
        [Test]
        [TestCase(new [] {21, 55, 8, 62, 16})]
        public void MySortedList_NotEmptyListContainsElemIsTrue(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            // Assert
            list.Contains(8).Should().BeTrue();
        }
        [Test]
        [TestCase(new [] {21, 55, 8, 62, 16})]
        public void MySortedList_NotEmptyListContainsElemIsFalse(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            // Assert
            list.Contains(9).Should().BeFalse();
        }

        [Test]
        public void MySortedList_GetInsertIndexOfEmptyListIsZero()
        {
            // Arrange +Act 
            var list = new MySortedList<int>();
            
            // Assert
            list.GetInsertIndex(9).Should().Be(0);

        }

        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_GetInsertIndexForNotEmptyListGreatestElemIsCount(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            // Assert
            list.GetInsertIndex(100).Should().Be(list.Count);
        }
        [Test]
        public void MySortedList_RemoveElementFromEmptyListIsFalse()
        {
            // Arrange + Act
            var list = new MySortedList<int>();
            
            // Assert
            list.Remove(4).Should().BeFalse();
        }
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_RemoveElementFromNotEmptyListIsTrue(int [] elems)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            
            // Assert
            list.Remove(21).Should().BeTrue();
        }
        
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_RemovedElementIsNotInList(int [] elems)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            list.Remove(21).Should().BeTrue();
            
            // Assert
            list.Contains(21).Should().BeFalse();
        }
        [Test]
        public void MySortedList_IndexOfElemInEmptyListIsMunusOne()
        {
            // Arrange + Act
            var list = new MySortedList<int>();
            
            // Assert
            list.IndexOf(4).Should().Be(-1);
        }
        [Test]
        [TestCase(9)]
        public void MySortedList_IndexOfElemInOneElemListIsZero(int elem)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            list.Add(elem);
            
            // Assert
            list.IndexOf(elem).Should().Be(0);
        }
        
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_CopyToEmptyListEqualToInsertion(int [] elems)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            list.CopyTo(elems, 0);
            
            // Assert
            list.Equals(elems);
        }
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_ListAfterCopyToIsSorted(int [] elems)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            list.CopyTo(elems, 0);
            
            // Assert
            list.Should().BeInAscendingOrder();
        }
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_CopyTo3(int [] elems)
        {
            // Arrange 
            var list = new MySortedList<int>();
            
            // Act 
            list.CopyTo(elems, 0);
            
            // Assert
            list.Contains(21).Should().BeTrue();
        }
        
        [Test]
        [TestCase(new[] {21, 55, 8, 62, 16})]
        public void MySortedList_GetEnumeratorEnumerateItemsInList_ReturnItemsFromList(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            Array.Sort(elems);

            var i = 0;
            // Act
            foreach (var elem in list)
            {
                // Assert
                elem.Should().Be(elems[i]);
                i++;
            }
        }
        [Test]
        [TestCase(new[] {21, 55})]
        public void MySortedList_IndexOutOfRangeElemIsDefault(int [] elems)
        {
            // Arrange
            var list = new MySortedList<int>();
            foreach (var elem in elems)
            {
                list.Add(elem);
            }
            
            // Act
            var item = list[100];
            
            // Assert
            item.Should().Be(default);
        }
        
        [Test]
        [TestCase(3)]
        public void MySortedListEventArgs_ActionIsCorrect(int elem)
        {
            // Arrange
            var list = new MySortedList<int>();
            string ii = "";
            list.SortedListEvent += delegate(object sender, MySortedListEventArgs args)
            {
                ii = args.Action;
            };
            
            // Act
            list.Add(elem);
            
            // Assert
            ii.Should().Be("Add");
        }
        [Test]
        [TestCase(3)]
        public void MySortedListEventArgs_ItemCorrect(int elem)
        {
            // Arrange
            var list = new MySortedList<int>();
            string ii = "";
            list.SortedListEvent += delegate(object sender, MySortedListEventArgs args)
            {
                ii = args.Item;
            };
            
            // Act
            list.Add(elem);
            
            // Assert
            ii.Should().Be("3");
        }
        
        
        // Arrange
            // var list = new MySortedList<int>();
            // Act 
            
            // Assert
            
            
            
            
            
            
            
            
            // [Test]
            // public void MySortedList_IndexOfVoidListIs()
            // {
            //     // Arrange + Act
            //     var list = new MySortedList<int>();
            //     
            //     // Assert
            //     list[0].Should().NotBe(0);
            // }
    }
}