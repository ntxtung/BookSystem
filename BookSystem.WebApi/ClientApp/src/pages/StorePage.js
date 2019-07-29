import React from 'react'

import { connect } from 'react-redux'

import localhost5000 from '../apis/localhost5000'

import BookCard from '../components/BookCard'
import { Header, CardGroup } from 'semantic-ui-react';

class StorePage extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      books: []
    }
  }
  componentDidMount = async () => {
    let response = await localhost5000.get('./books')
    this.setState({ books: response.data })
  }
  render() {
    const mapBook = this.state.books.map((book) => {
      return (
        <BookCard key={book.id} book={book} />
      )
    })
    return (
      <div>
        <Header as='h2' textAlign='center'>
          <Header.Content>You can rent others' books here</Header.Content>
        </Header>
        <CardGroup doubling itemsPerRow={5}>
          {mapBook}
        </CardGroup>
        
      </div>

    )
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {})(StorePage)