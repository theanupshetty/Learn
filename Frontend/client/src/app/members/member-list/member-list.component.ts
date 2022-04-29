import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/_models/members';
import { MembersService } from 'src/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
})
export class MemberListComponent implements OnInit {
  members$: Observable<Member[]>;
  constructor(private memberService: MembersService) {}

  ngOnInit(): void {
    this.members$= this.memberService.getMembers();
  }

  
}
