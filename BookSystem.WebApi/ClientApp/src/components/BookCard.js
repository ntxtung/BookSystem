import React from 'react'
import { Card, Icon, Image } from 'semantic-ui-react'

export default class BookCard extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      nothing: true
    }
  }

  handleBookImage = () => {
    if (this.props.book !== undefined && this.props.book !== null) {
        if (this.props.book.image !== null && this.props.book.image.length > 0){
          return this.props.book.image
        }
    }
    return process.env.PUBLIC_URL + "placeholder-book-cover-default.png"
  }

  render() {
    return (
      <Card >
        <Image src={this.handleBookImage()} wrapped ui={true} size='medium'/>
        <Card.Content>
          <Card.Header>{this.props.book.title}</Card.Header>
          <Card.Meta>
            <span className='date'>Joined in 2015</span>
          </Card.Meta>
          <Card.Description>
            Matthew is a musician living in Nashville.
          </Card.Description>
        </Card.Content>
        <Card.Content extra>
          <a>
            <Icon name='user' />
            22 Friends
          </a>
        </Card.Content>
      </Card>
    )
  }
}