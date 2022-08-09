/**
 * Class to represent a Node in a Binary Search Tree (BST).
 */
class BSTNode {

    constructor(data) {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

class BinarySearchTree {
    constructor() {
        this.root = null;
    }


    contains(searchVal) {
        if(this.isEmpty()){
            return false;
        }
        let current = this.root
        while (current) {
            if(current.data === searchVal){
                return true;
            }
            if(searchVal < current.data){
                current = current.left;
            } 
            else{
                current = current.right;
            }
        }
        return false;
    }


    containsRecursive(searchVal, current = this.root) {
        if(this.isEmpty() || current === null){
            return false;
        }
        if(current.data === searchVal){
            return true;
        }
        if(searchVal < current.data){
            return this.containsRecursive(searchVal, current.left)
        }
        if(searchVal > current.data){
            return this.containsRecursive(searchVal, current.right)
        }
    }


    range(startNode = this.root) {
        if(startNode === null){
            return 0;
        }
        return this.max(startNode) - this.min(startNode);
    }


    isEmpty() {
        return this.root === null;
    }


    min(current = this.root) {
        if(this.isEmpty()){
            return null;
        }
        while(current.left){
            current = current.left;
        }
        return current.data;
    }


    minRecursive(current = this.root) {
        if (current === null) {
            return null;
        }
        if (current.left === null) {
            return current.data;
        }
        return this.minRecursive(current.left);
    }


    max(current = this.root) {
        if(this.isEmpty()){
            return null;
        }
        while(current.right){
            current = current.right;
        }
        return current.data;
    }


    maxRecursive(current = this.root) {
        if (current === null) {
            return null;
        }
        if (current.right === null) {
            return current.data;
        }
        return this.maxRecursive(current.right);
    }


    // Logs this tree horizontally with the root on the left.
    print(node = this.root, spaceCnt = 0, spaceIncr = 10) {
        if (!node) {
            return;
        }
        spaceCnt += spaceIncr;
        this.print(node.right, spaceCnt);
        console.log(" ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +`${node.data}`);
        this.print(node.left, spaceCnt);
    }
}

const emptyTree = new BinarySearchTree();
const oneNodeTree = new BinarySearchTree();
oneNodeTree.root = new BSTNode(10);

/* twoLevelTree
        root
        10
    /   \
    5     15
*/
const twoLevelTree = new BinarySearchTree();
twoLevelTree.root = new BSTNode(10);
twoLevelTree.root.left = new BSTNode(5);
twoLevelTree.root.right = new BSTNode(15);
console.log(twoLevelTree.range());

/* threeLevelTree 
        root
        10
    /   \
    5     15
/ \    / \
2   6  13  
*/
const threeLevelTree = new BinarySearchTree();
threeLevelTree.root = new BSTNode(10);
threeLevelTree.root.left = new BSTNode(5);
threeLevelTree.root.left.left = new BSTNode(2);
threeLevelTree.root.left.right = new BSTNode(6);
threeLevelTree.root.right = new BSTNode(15);
threeLevelTree.root.right.left = new BSTNode(13);

/* fullTree
                    root
                <-- 25 -->
            /            \
            15             50
        /    \         /    \
        10     22      35     70
    /   \   /  \    /  \   /  \
    4    12  18  24  31  44 66  90
*/
/***************** Uncomment after insert method is created. ****************/
// const fullTree = new BinarySearchTree();
// console.log(fullTree.insert(25));
//     // .insert(15)
//     // .insert(10)
//     // .insert(22)
//     // .insert(4)
//     // .insert(12)
//     // .insert(18)
//     // .insert(24)
//     // .insert(50)
//     // .insert(35)
//     // .insert(70)
//     // .insert(31)
//     // .insert(44)
//     // .insert(66)
//     // .insert(90));
