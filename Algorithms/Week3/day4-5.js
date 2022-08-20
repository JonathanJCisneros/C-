
class DLLNode{
    constructor(data){
        this.data = data;
        this.next = null;
        this.prev = null;
    }
}

class DoublyLinkedList {
    constructor() {
        this.head = null;
        this.tail = null;
    }


    /**
     * Inserts a new node with the given newVal after the node that has the
     * given targetVal as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} targetVal The node data to find.
     * @param {any} newVal Data for the new node.
     * @returns {boolean} Indicates if the new node was added.
     */
    insertAfter(targetVal, newVal) {
        const insertVal = new DLLNode(newVal);
        if(this.isEmpty()){
            return false;
        }

        const current = this.head
        while(current !== targetVal || !current.next){
            current = current.next;
        }

        current.next = insertVal;
        return true;
    }

    /**
      * Inserts a new node with the given newVal before the node that has the
      * given targetVal as it's data.
      * - Time: O(?).
      * - Space: O(?).
      * @param {any} targetVal The node data to find.
      * @param {any} newVal Data for the new node.
      * @returns {boolean} Indicates if the new node was added.
      */
    insertBefore(targetVal, newVal) {}


    insertAtFront(data) {
        const newHead = new DLLNode(data);
        if (this.isEmpty()) {
        this.head = newHead;
        this.tail = newHead;
        } else {
        const oldHead = this.head;
        oldHead.prev = newHead;
        newHead.next = oldHead;
        this.head = newHead;
        }
        return this;
    }


    insertAtBack(data) {
        const newTail = new DLLNode(data);
        if (this.isEmpty()) {
        this.head = newTail;
        this.tail = newTail;
        } 
        else {
        this.tail.next = newTail;
        newTail.prev = this.tail;
        this.tail = newTail;
        }
        return this;
    }


    removeMiddleNode() {
        if (!this.isEmpty() && this.head === this.tail) {
            const removedData = this.head.data;
            this.head = null;
            this.tail = null;
            return removedData;
        }

        let forwardRunner = this.head;
        let backwardsRunner = this.tail;

        while (forwardRunner && backwardsRunner) {
            if (forwardRunner === backwardsRunner) {
                const midNode = forwardRunner;
                midNode.prev.next = midNode.next;
                midNode.next.prev = midNode.prev;
                return midNode.data;
            }

            if (forwardRunner.prev === backwardsRunner) {
                return null;
            }

            forwardRunner = forwardRunner.next;
            backwardsRunner = backwardsRunner.prev;
        }
        return null;
    }


    isEmpty() {
        return this.head === null;
    }


    toArray() {
        const vals = [];
        let runner = this.head;

        while (runner) {
        vals.push(runner.data);
        runner = runner.next;
        }
        return vals;
    }


    insertAtBackMany(items = []) {
        items.forEach((item) => this.insertAtBack(item));
        return this;
    }
}

const emptyList = new DoublyLinkedList();

/**************** Uncomment these test lists after insertAtBack is created. ****************/
// const singleNodeList = new DoublyLinkedList().insertAtBack(1);
// const biNodeList = new DoublyLinkedList().insertAtBack(1).insertAtBack(2);
const firstThreeList = new DoublyLinkedList().insertAtBackMany([1, 2, 3]).insertAtFront(6).insertAtFront(2);
// const secondThreeList = new DoublyLinkedList().insertAtBackMany([4, 5, 6]);
// const unorderedList = new DoublyLinkedList().insertAtBackMany([
//   -5,
//   -10,
//   4,
//   -3,
//   6,
//   1,
//   -7,
//   -2,
// ]);

console.log(firstThreeList.toArray());