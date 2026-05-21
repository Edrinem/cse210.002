using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with distinct priorities (low=1, medium=2, high=3).
    //           Dequeue all three items one by one.
    // Expected Result: Items dequeued in priority order: "High"(3), "Medium"(2), "Low"(1).
    // Defect(s) Found: 
    //   1. The loop used `index < _queue.Count - 1`, skipping the last element,
    //      so the last-added item was never considered as a candidate for highest priority.
    //   2. The item was never removed from the list after being selected (missing RemoveAt),
    //      causing Dequeue to return the same item every time and the queue to never shrink.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items where two share the highest priority.
    //           Verify that FIFO order is respected for equal-priority items
    //           (the first one enqueued at that priority is dequeued first).
    // Expected Result: "First"(5) is returned before "Second"(5); then "Other"(1).
    // Defect(s) Found:
    //   The tie-breaking comparison used `>=` instead of `>`, meaning a later
    //   equal-priority item would overwrite the winner index and be dequeued first,
    //   violating the FIFO requirement for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Other", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Other", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: No defect — the empty-queue guard was already correctly implemented.
    public void TestPriorityQueue_3_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item, then dequeue it.
    // Expected Result: That single item is returned and the queue is then empty.
    // Defect(s) Found:
    //   The off-by-one loop bug (`< _queue.Count - 1`) meant that with only one item,
    //   the loop body never ran and index 0 was correctly used — however the missing
    //   RemoveAt still caused the item to remain in the queue after dequeue.
    public void TestPriorityQueue_4_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 10);

        string result = priorityQueue.Dequeue();
        Assert.AreEqual("OnlyItem", result);

        // Queue must now be empty — a second dequeue should throw
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}