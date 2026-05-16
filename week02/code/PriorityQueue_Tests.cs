using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities.
    // Expected Result: Item with highest priority should be removed first.
    // Defect(s) Found: Last item in the queue was not checked because the loop
    // stopped too early.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Tim", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", result);
    }

    [TestMethod]
    // Scenario: Add several items with the same priority.
    // Expected Result: Items with equal priority should follow FIFO order.
    // Defect(s) Found: Queue removed the newest item instead of the oldest
    // when priorities matched.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 5);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove an item from the queue.
    // Expected Result: Item should be removed from the queue after dequeue.
    // Defect(s) Found: Item was returned but not removed from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 2);

        priorityQueue.Dequeue();

        Assert.AreEqual("[Bob (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown with correct message.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                e.GetType(), e.Message)
            );
        }
    }
}