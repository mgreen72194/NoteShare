import React, {Component} from 'react'
import axios from 'axios'


class NoteList extends React.Component {
	constructor(props) {
		super(props)
		this.state = {note: [], loading: true, text: 'hello world'};
	}

	async componentDidMount() {
		this.setState({text: 'something else'})
		const response = await axios.get('https://localhost:44334/note/get')
		this.setState({
				note: response.data,
				loading: false,
				text: 'hello world!'
			})
		console.log(this.state.note)
	}

	static renderNotes(notes) {
		return (
			<table className='table table-striped' aria-labelledby="tabelLabel">
			  <thead>
				<tr>
				  <th>Author</th>
				  <th>Content</th>
				  <th>Course</th>
				</tr>
			  </thead>
			  <tbody>
				{notes.map(note =>
				  <tr key={note.id}>
					<td>{note.author}</td>
					<td>{note.content}</td>
					<td>{note.course}</td>
				  </tr>
				)}
			  </tbody>
			</table>
		  );
	}

	render() {
		let contents = NoteList.renderNotes(this.state.note)
		return (
			<div>
				<h1>This is the NoteList</h1>
				{contents}
			</div>
		)
	}
}


export default NoteList;
