class TreeNode {
    constructor(value) {
        this.value = value;
        this.children = [];
    }

    addChild(node) {
        this.children.push(node);
    }
}

class Tree {
    constructor(rootValue) {
        this.root = new TreeNode(rootValue);
    }

    traverseDFS(node = this.root) {
        console.log(node.value);
        for (let child of node.children) {
            this.traverseDFS(child);
        }
    }
    
    /*
    traversePostOrder(node = this.root) {
        for (let child of node.children) {
            this.traversePostOrder(child); 
        }
        console.log(node.value); 
    }
        */
}

const tree = new Tree("Raíz");
const child1 = new TreeNode("Hijo 1");
const child2 = new TreeNode("Hijo 2");
const child3 = new TreeNode("Hijo 3");

tree.root.addChild(child1);
tree.root.addChild(child2);
child1.addChild(child3);

console.log("Recorrido DFS:");
tree.traverseDFS();
