import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    // set up state and bindings
    constructor() {
        super();

        this.state = {
            restaurants: [],
            selectedItems: [],
            loading: true,
            search: null
        };

        this.handleSelectItem = this.handleSelectItem.bind(this);
        this.submitOrder = this.submitOrder.bind(this);
    }

    searchSpace = (event) => {
        let keyword = event.target.value;
        this.setState({ search: keyword })
    }

    // add event listeners
    componentDidMount() {
        this.populateRestaurantData();
    }

    // remove event listeners
    componentWillUnmount() {
    }

    // handle toggle checkboxes
    handleSelectItem(e) {
        const { value } = e.target;
        const nextValue = this.getNextValue(value);

        this.setState({ selectedItems: nextValue, lastSelectedItem: value });
    }

    // get the next value or range of values to select
    getNextValue(value) {
        const { selectedItems } = this.state;                

        // if it's already in there, remove it, otherwise append it
        return selectedItems.includes(value)
            ? selectedItems.filter(item => item !== value)
            : [...selectedItems, value];
    }

    // render our list items
    renderItems() {
        const { restaurants } = this.state;
        
        return (
            <ul>
                {restaurants.map(restaurant => (
                    <li key={restaurant.id}>
                        <div>{restaurant.name} - {restaurant.suburb} - rated #{restaurant.rank} overall</div>
                        <ul>
                            {restaurant.categories.map(category => (
                                <li key={category.name}>
                                    <div>{category.name}</div>
                                    <ul>
                                        {category.menuItems.map(menuItem =>
                                            (
                                                <li key={menuItem.id}>
                                                    <input
                                                        onChange={this.handleSelectItem}
                                                        type="checkbox"
                                                        value={menuItem.id}
                                                        id={menuItem.id}
                                                    />
                                                    <label>&nbsp;{menuItem.name} - R{menuItem.price}</label>
                                                </li>
                                            )
                                        )}
                                    </ul>
                                </li>
                            ))}
                        </ul>
                    </li>
                ))}

            </ul>
        );
    }

    render() {
            let contents = this.state.loading
                ? <p><em>Loading...</em></p>
                : <div>
                    <ul ref={node => (this.listEl = node)}>{this.renderItems()}</ul>
                    <button onClick={this.submitOrder}> Place order </button>
                </div>
        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <input type="text" placeholder="Enter item to be searched"  onChange={(e) => this.searchSpace(e)} />
                {contents}
            </div>

        );
    }

    async submitOrder() {
        const { selectedItems } = this.state;   
        const responce = await fetch('api/restaurant', { method: 'POST', headers: { 'Content-Type': 'application/json' },  body: JSON.stringify(selectedItems) });

        if (responce.status == 200)
            alert("Your order has been placed!\nLeave the rest up to our chefs and our drivers!");
        else
            alert("Oops! Something went wrong on our end. Please try to place your order again.");
    }

    async populateRestaurantData() {
        const response = await fetch('api/restaurant');
        const data = await response.json();
        this.setState({ restaurants: data, loading: false });
    }

}