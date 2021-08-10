import React from "react";



export default class CreateNote extends React.Component {
	constructor(props) {
		super(props);
		this.state = {note: null, loading: false};
	}

	render() {
		return(
			<div>
				<h1>Hello World</h1>
				{/* create a note submit form
				onsubmit call post funciton to post to the api */}
			</div>
		)
	}
}