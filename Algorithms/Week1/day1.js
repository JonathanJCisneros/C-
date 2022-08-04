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

    secondToLast() {
        if(this.isEmpty() || this.head.next === null){
            return null;
        }
        let currentNode = this.head;
        while(currentNode.next.next !== null){
            currentNode = currentNode.next;
        }
        return currentNode.data;
    }
    
    removeVal(val) {
        if(this.isEmpty()){
            return null;
        }
        let previousNode = this.head;
        let currentNode = this.head.next;
        if(previousNode.data === val){
            this.removeHead();
            return true;
        }
        while(currentNode){
            if(currentNode.data === val){
                previousNode.next = currentNode.next;
                return true;
            }
            previousNode = currentNode;
            currentNode = currentNode.next;
        }
        return false;
    }

     // EXTRA
    /**
      * Inserts a new node before a node that has the given value as its data.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} newVal The value to use for the new node that is being added.
      * @param {any} targetVal The value to use to find the node that the newVal
      *    should be inserted in front of.
      * @returns {boolean} To indicate whether the node was pre-pended or not.
      */
    prepend(newVal, targetVal) {}

    removeBack(){
        if (this.isEmpty()){
            return null;
        }
        if(this.head.next === null){
            return this.removeHead();
        }
        let currentNode = this.head;
        while(currentNode.next.next){
            currentNode = currentNode.next;
        }
        const removedNode = currentNode.next;
        currentNode.next = null;
        return removedNode;
    }

    contains(val) {
        let current = this.head;

        while(current !== null){
            if(current.data == val){
                return true;
            }
            current = current.next;
        }
        return false;
    }

    containsRecursive(val, current = this.head) {
        if(current === null){
            return false;
        }
        if(current.data === val){
            return true;
        }
        return this.containsRecursive(val, current.next)
    }

    recursiveMax(runner = this.head, maxNode = this.head) {
        if (this.head === null) {
            return null;
        }
        if (runner === null) {
            return maxNode.data;
        }
        if (runner.data > maxNode.data) {
            maxNode = runner;
        }
        return this.recursiveMax(runner.next, maxNode);
    }

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

// const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
// console.log(singleNodeList.toArr());
// const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
// console.log(biNodeList.toArr());
// const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
// console.log(firstThreeList.toArr());
// const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
// console.log(secondThreeList.toArr());
// const unorderedList = new SinglyLinkedList().insertAtBackMany([-5, -10, 4, -3, 6, 1, -7, -2,]);
// console.log(unorderedList.toArr());

const unorderedList1 = new SinglyLinkedList().insertAtBackMany([-5, -10, 4, -3, 6, 1, -7, -2]).removeVal(6);
console.log(unorderedList1);

// /* node 4 connects to node 1, back to head */
// const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// perfectLoopList.head.next.next.next = perfectLoopList.head;

// /* node 4 connects to node 2 */
// const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// loopList.head.next.next.next = loopList.head.next;

// const sortedDupeList = new SinglyLinkedList().insertAtBackMany([1, 1, 1, 2, 3, 3, 4, 5, 5,]);

// // Print your list like so:
// console.log(firstThreeList.toArr());