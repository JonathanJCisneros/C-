/**
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 */
class MinHeap {
    constructor() {
    this.heap = [null];
    }


    top() {
        return this.heap.length > 1? this.heap[1]: null;
    }


    insert(num){
        this.heap.push(num)
        let currentIdx = this.heap.length - 1;
        while(this.heap[currentIdx] < this.heap[Math.floor(currentIdx/2)]){
            let temp = this.heap[Math.floor(currentIdx/2)]
            this.heap[Math.floor(currentIdx/2)] = this.heap[currentIdx]
            this.heap[currentIdx] = temp;
            currentIdx = Math.floor(currentIdx/2)
        }
    }


    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
        if (parentIdx > this.heap.length - 1) {
        return;
        }

        spaceCnt += spaceIncr;
        this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

        console.log(
        " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${this.heap[parentIdx]} (${parentIdx})`
        );

        this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
}

const newHeap = new MinHeap();

newHeap.insert(5)
newHeap.insert(7)
newHeap.insert(3)

newHeap.printHorizontalTree()

