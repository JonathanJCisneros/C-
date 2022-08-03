/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class SinglyLinkedList {
    constructor() {
        this.head = null;
    }

    /**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed.
     */
    removeBack() {}

    /**
      * Determines whether or not the given search value exists in this list.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} val The data to search for in the nodes of this list.
      * @returns {boolean}
      */
    contains(val) {}

    /**
      * Determines whether or not the given search value exists in this list.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} val The data to search for in the nodes of this list.
      * @param {?ListNode} current The current node during the traversal of this list
      *    or null when the end of the list has been reached.
      * @returns {boolean}
      */
    containsRecursive(val, current = this.head) {}

     // EXTRA
    /**
      * Recursively finds the maximum integer data of the nodes in this list.
      * - Time: O(?).
      * - Space: O(?).
      * @param {ListNode} runner The start or current node during traversal, or null
      *    when the end of the list is reached.
      * @param {ListNode} maxNode Keeps track of the node that contains the current
      *    max integer as it's data.
      * @returns {?number} The max int or null if none.
      */
    recursiveMax(runner = this.head, maxNode = this.head) {}

    insertAtFront(data) {
        const newNode = new ListNode(data);
        newNode.next = this.head;
        this.head = newNode;
        return this;
    }

    removeHead() {
        let deleted = this.head;
        this.head = this.head.next;
        return deleted.data;
    }

    average() {
        let sum = 0;
        let count = 0;
        let runner = this.head;
        while(runner){
            count++;
            sum += runner.data;
            runner = runner.next;
        } 
        return sum/count;
    }

    isEmpty() {
        if(this.head === null){
            return true;
        }
        else{
            return false;
        }
    }

    insertAtBack(data) {
        if (this.isEmpty()){
            this.head = new ListNode(data);
            this.next = null;
        }
        else {
            let current = this.head;
            while(current.next !== null){
                current = current.next;
            }
            current.next = new ListNode(data);
        }
        return this;
    }

    insertAtBackRecursive(data, runner = this.head) {
        if(runner.next !== null){
            this.insertAtBackRecursive(data, runner = runner.next)
        }
        else{
            runner.next = new ListNode(data);
        }
        return this;
    }

    insertAtBackMany(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }

    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}

const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
console.log(singleNodeList.toArr());
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
console.log(biNodeList.toArr());
const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
console.log(firstThreeList.toArr());
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
console.log(secondThreeList.toArr());
const unorderedList = new SinglyLinkedList().insertAtBackMany([-5, -10, 4, -3, 6, 1, -7, -2,]);
console.log(unorderedList.toArr());

/* node 4 connects to node 1, back to head */
const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
perfectLoopList.head.next.next.next = perfectLoopList.head;

/* node 4 connects to node 2 */
const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
loopList.head.next.next.next = loopList.head.next;

const sortedDupeList = new SinglyLinkedList().insertAtBackMany([1, 1, 1, 2, 3, 3, 4, 5, 5,]);

// Print your list like so:
console.log(firstThreeList.toArr());